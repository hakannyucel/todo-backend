using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
  public class TodoDto : IDto
  {
    public Guid id { get; set; }
    public string task { get; set; }
    public string description { get; set; }
    public DateTime created_date { get; set; }
    public DateTime? due_date { get; set; }
    public List<TagDto> tags { get; set; }
  }
}
