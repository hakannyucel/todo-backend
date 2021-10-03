using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Logging
{
  public class LogAspect : MethodInterception
  {
    private LoggerService _loggerService;

    public LogAspect(Type loggerService)
    {
      if (loggerService.BaseType != typeof(LoggerService))
      {
        throw new System.Exception(AspectMessages.InvalidLoggerType);
      }

      _loggerService = (LoggerService)Activator.CreateInstance(loggerService);
    }

    protected override void OnBefore(IInvocation invocation)
    {
      _loggerService.Info(GetLogDetail(invocation));
    }

    protected override void OnException(IInvocation invocation, System.Exception error)
    {
      _loggerService.Error(GetLogDetail(invocation));
    }

    private LogDetail GetLogDetail(IInvocation invocation)
    {
      var parameters = new List<LogParameter>();
      for (int i = 0; i < invocation.Arguments.Length; i++)
      {
        parameters.Add(new LogParameter
        {
          Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
          Value = invocation.Arguments[i],
          Type = invocation.Arguments[i].GetType().Name
        });
      }

      var logDetail = new LogDetail
      {
        FullName = invocation.Method.DeclaringType == null ? null : invocation.Method.DeclaringType.Name,
        MethodName = invocation.Method.Name,
        Parameters = parameters
      };

      return logDetail;
    }
  }
}
