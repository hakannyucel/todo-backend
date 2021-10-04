using AutoMapper;

namespace Business.DependencyResolvers.AutoMapper
{
  public interface IAutoMapperService
  {
    IMapper Mapper { get; }

  }
}
