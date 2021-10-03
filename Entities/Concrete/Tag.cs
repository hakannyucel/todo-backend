using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
  public class Tag : IEntity
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<TodoTag> TodoTags { get; set; }
  }
}
