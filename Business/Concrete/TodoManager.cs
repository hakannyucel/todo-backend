using Business.Abstract;
using Business.DependencyResolvers.AutoMapper;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Business;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
  public class TodoManager : AutoMapperService, ITodoService
  {
    private readonly ITodoDal _todoDal;
    private readonly ITodoTagService _todoTagService;
    private readonly ITagService _tagService;

    public TodoManager(ITodoDal todoDal, ITodoTagService todoTagService, ITagService tagService)
    {
      _todoDal = todoDal;
      _todoTagService = todoTagService;
      _tagService = tagService;
    }

    [PerformanceAspect(5)]
    [LogAspect(typeof(FileLogger))]
    [LogAspect(typeof(DatabaseLogger))]
    [CacheAspect]
    public IDataResult<List<TodoDto>> GetAll()
    {
      return new SuccessDataResult<List<TodoDto>>(Mapper.Map<List<TodoDto>>(_todoDal.GetAll()));
    }

    [PerformanceAspect(5)]
    [LogAspect(typeof(FileLogger))]
    [LogAspect(typeof(DatabaseLogger))]
    [CacheAspect]
    public IDataResult<List<TodoDto>> GetAllByTag(string tag)
    {
      return new SuccessDataResult<List<TodoDto>>(Mapper.Map<List<TodoDto>>(_todoDal.GetAll(x => x.TodoTags.Select(y => y.Tag.Name).Contains(tag))));
    }

    [PerformanceAspect(5)]
    [TransactionScopeAspect]
    [CacheRemoveAspect("ITodoService.Get")]
    [LogAspect(typeof(FileLogger))]
    [LogAspect(typeof(DatabaseLogger))]
    [ValidationAspect(typeof(TodoValidator))]
    public IResult Add(TodoDto todo)
    {
      var result = BusinessRules.Run(CheckIfTodoTaskNameAlreadyExists(todo.task));

      if (result != null)
        return result;

      var model = Mapper.Map<Todo>(todo);

      _todoDal.Add(model);

      foreach (var tag in todo.tags)
      {
        _todoTagService.Add(new TodoTag
        {
          TagId = _tagService.GetByName(tag.name).Data.Id,
          TodoId = model.Id
        });
      }

      return new SuccessResult();
    }


    [TransactionScopeAspect]
    [LogAspect(typeof(FileLogger))]
    [LogAspect(typeof(DatabaseLogger))]
    [CacheRemoveAspect("ITodoService.Get")]
    [PerformanceAspect(5)]
    public IResult ToggleCompleted(Guid id)
    {
      var result = BusinessRules.Run(CheckIfTodoNotExists(id));
      if (result != null)
        return result;

      var model = _todoDal.Get(x => x.Id == id);
      model.IsComplete = !model.IsComplete;
      _todoDal.Update(model);

      return new SuccessResult();
    }

    private IResult CheckIfTodoTaskNameAlreadyExists(string task)
    {
      if (_todoDal.Get(x => x.Task == task) != null)
        return new ErrorResult(BusinessMessages.TaskNameAlreadyExists);

      return new SuccessResult();
    }

    private IResult CheckIfTodoNotExists(Guid id)
    {
      if (_todoDal.Get(x => x.Id == id) != null)
        return new ErrorResult(BusinessMessages.TaskNotFound);

      return new SuccessResult();
    }
  }
}
