using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
  public class TodoManager : ITodoService
  {
    private readonly ITodoDal _todoDal;

    public TodoManager(ITodoDal todoDal)
    {
      _todoDal = todoDal;
    }

    [LogAspect(typeof(FileLogger))]
    [LogAspect(typeof(DatabaseLogger))]
    [CacheAspect]
    public IDataResult<List<Todo>> GetAll()
    {
      return new SuccessDataResult<List<Todo>>(_todoDal.GetAll());
    }

    // Performance Test
    [TransactionScopeAspect]
    [CacheRemoveAspect("ITodoService.Get")]
    [LogAspect(typeof(FileLogger))]
    [LogAspect(typeof(DatabaseLogger))]
    [ValidationAspect(typeof(TodoValidator))]
    public IResult Add(Todo todo)
    {
      _todoDal.Add(todo);
      return new SuccessResult();
    }
  }
}
