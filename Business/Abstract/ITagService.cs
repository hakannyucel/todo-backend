using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;

namespace Business.Abstract
{
  public interface ITagService
  {
    IDataResult<List<TagDto>> GetAll();
    IResult Add(TagDto tag);
    IDataResult<Tag> GetByName(string tag);
  }
}
