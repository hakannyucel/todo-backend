using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
  public class AutofacBusinessModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<EfTodoDal>().As<ITodoDal>().SingleInstance();
      builder.RegisterType<TodoManager>().As<ITodoService>().SingleInstance();

      builder.RegisterType<EfTagDal>().As<ITagDal>().SingleInstance();
      builder.RegisterType<TagManager>().As<ITagService>().SingleInstance();


      // AOP Injection
      var assembly = System.Reflection.Assembly.GetExecutingAssembly();

      builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
        .EnableInterfaceInterceptors(new ProxyGenerationOptions
        {
          Selector = new AspectInterceptionSelector()
        });
    }
  }
}
