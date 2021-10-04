using AutoMapper;

namespace Business.DependencyResolvers.AutoMapper
{
  public abstract class AutoMapperService : IAutoMapperService
  {
    public IMapper Mapper
    {
      get { return ObjectMapper.Mapper; }
    }
  }

}
