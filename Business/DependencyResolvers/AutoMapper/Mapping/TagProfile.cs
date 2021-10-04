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
  public class TagProfile : Profile
  {
    public TagProfile()
    {
      CreateMap<Tag, TagDto>()
        .ForMember(x => x.name, y => y.MapFrom(z => z.Name));

      CreateMap<TagDto, Tag>()
        .ForMember(x => x.Name, y => y.MapFrom(z => z.name));
    }
  }
}
