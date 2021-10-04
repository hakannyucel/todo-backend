using Business.Abstract;
using Core.DataAccess;
using Core.Utilities.Business;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
  public class TodoTagManager : ITodoTagService
  {
    private readonly ITodoTagDal _todoTagDal;

    public TodoTagManager(ITodoTagDal todoTagDal)
    {
      _todoTagDal = todoTagDal;
    }

    public IResult Add(TodoTag todoTag)
    {
      var result = BusinessRules.Run(CheckIfTodoTagAlreadyExists(todoTag.TodoId, todoTag.TagId));
      if (result != null)
        return result;

      _todoTagDal.Add(todoTag);

      return new SuccessResult();
    }

    #region Logics
    private IResult CheckIfTodoTagAlreadyExists(Guid todo, Guid tag)
    {
      if (_todoTagDal.Get(x => x.TodoId == todo & x.TagId == tag) != null)
        return new ErrorResult(BusinessMessages.TodoTagAlreadyExists);

      return new SuccessResult();
    }
    #endregion
  }
}
