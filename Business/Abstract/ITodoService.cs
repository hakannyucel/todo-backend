using Core.Utilities.Results;
using Entities.Dtos;
using System;
using System.Collections.Generic;

namespace Business.Abstract
{
  public interface ITodoService
  {
    IDataResult<List<TodoDto>> GetAll();
    IDataResult<List<TodoDto>> GetAllByTag(string tag);
    IResult Add(TodoDto todo);
    IResult ToggleCompleted(Guid id);
  }
}
