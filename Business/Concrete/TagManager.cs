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
using System.Collections.Generic;

namespace Business.Concrete
{
  public class TagManager : AutoMapperService, ITagService
  {
    private readonly ITagDal _tagDal;

    public TagManager(ITagDal tagDal)
    {
      _tagDal = tagDal;
    }

    [CacheAspect]
    [PerformanceAspect(5)]
    public IDataResult<List<TagDto>> GetAll()
    {
      return new SuccessDataResult<List<TagDto>>(Mapper.Map<List<TagDto>>(_tagDal.GetAll()));
    }

    [LogAspect(typeof(FileLogger))]
    [LogAspect(typeof(DatabaseLogger))]
    [ValidationAspect(typeof(TagValidator))]
    [TransactionScopeAspect]
    [CacheRemoveAspect("ITagService.Get")]
    public IResult Add(TagDto tag)
    {
      var result = BusinessRules.Run(CheckIfTagAlreadyExists(tag.name));

      if (result != null)
        return result;

      var model = Mapper.Map<Tag>(tag);

      _tagDal.Add(model);

      return new SuccessResult();
    }

    [LogAspect(typeof(FileLogger))]
    [LogAspect(typeof(DatabaseLogger))]
    [CacheAspect]
    [PerformanceAspect(5)]
    public IDataResult<Tag> GetByName(string tag)
    {
      return new SuccessDataResult<Tag>(_tagDal.Get(x => x.Name == tag));
    }

    #region Logics
    private IResult CheckIfTagAlreadyExists(string tag)
    {
      if (_tagDal.Get(x => x.Name == tag) != null)
        return new ErrorResult(BusinessMessages.TagAlreadyExists);

      return new SuccessResult();
    }
    #endregion
  }
}
