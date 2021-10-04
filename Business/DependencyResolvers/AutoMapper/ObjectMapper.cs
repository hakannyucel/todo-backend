using AutoMapper;
using System;

namespace Business.DependencyResolvers.AutoMapper
{
  public class ObjectMapper
  {
    public static IMapper Mapper
    {
      get { return mapper.Value; }
    }

    public static IConfigurationProvider Configuration
    {
      get { return config.Value; }
    }

    public static Lazy<IMapper> mapper = new Lazy<IMapper>(() =>
    {
      var mapper = new Mapper(Configuration);
      return mapper;
    });

    public static Lazy<IConfigurationProvider> config = new Lazy<IConfigurationProvider>(() =>
    {
      var config = new MapperConfiguration(cfg =>
      {
        cfg.AddProfile<Mapping.TodoProfile>();
        cfg.AddProfile<Mapping.TagProfile>();
      });

      return config;
    });
  }

}
