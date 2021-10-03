using Core.Entities;
using System;

namespace Entities.Concrete
{
  public class TodoTag : IEntity
  {
    public Guid Id { get; set; }
    public Guid TodoId { get; set; }
    public Todo Todo { get; set; }
    public Guid TagId { get; set; }
    public Tag Tag { get; set; }
  }
}
