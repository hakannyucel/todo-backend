using AutoMapper;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.AutoMapper.Mapping
{
  public class TodoProfile : Profile
  {
    public TodoProfile()
    {
      CreateMap<Todo, TodoDto>()
        .ForMember(x => x.id, y => y.MapFrom(z => z.Id))
        .ForMember(x => x.task, y => y.MapFrom(z => z.Task))
        .ForMember(x => x.description, y => y.MapFrom(z => z.Description))
        .ForMember(x => x.created_date, y => y.MapFrom(z => z.CreatedDate))
        .ForMember(x => x.due_date, y => y.MapFrom(z => z.DueDate))
        .ForMember(x => x.tags, y => y.MapFrom(z => z.TodoTags.Where(j => j.Todo.Id == z.Id)));

      CreateMap<TodoDto, Todo>()
        .ForMember(x => x.Task, y => y.MapFrom(z => z.task))
        .ForMember(x => x.Description, y => y.MapFrom(z => z.description))
        .ForMember(x => x.CreatedDate, y => y.MapFrom(z => z.created_date))
        .ForMember(x => x.DueDate, y => y.MapFrom(z => z.due_date));
    }
  }
}
