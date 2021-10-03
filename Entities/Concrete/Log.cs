using Core.Entities;
using System;

namespace Entities.Concrete
{
  public class Log : IEntity
  {
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Detail { get; set; }
    public DateTime Date { get; set; }
    public string Audit { get; set; }
  }
}
