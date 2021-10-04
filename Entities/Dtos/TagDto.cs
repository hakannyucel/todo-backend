using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
  public class TagDto : IDto
  {
    public string name { get; set; }
  }
}
