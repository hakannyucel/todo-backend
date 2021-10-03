using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Logging.Log4Net
{
  public class LoggerService
  {
    private ILog _log;

    public LoggerService(ILog log)
    {
      _log = log;
    }

    public bool IsInfoEnabled => _log.IsInfoEnabled;
    public bool IsDebugEnabled => _log.IsDebugEnabled;
    public bool IsWarnEnabled => _log.IsWarnEnabled;
    public bool IsFatalEnabled => _log.IsFatalEnabled;
    public bool IsErrorEnabled => _log.IsFatalEnabled;

    public void Info(object logMessage)
    {
      if (IsInfoEnabled)
        _log.Info(JsonConvert.SerializeObject(logMessage));
    }

    public void Debug(object logMessage)
    {
      if (IsDebugEnabled)
        _log.Debug(JsonConvert.SerializeObject(logMessage));
    }

    public void Warn(object logMessage)
    {
      if (IsWarnEnabled)
        _log.Warn(JsonConvert.SerializeObject(logMessage));
    }

    public void Fatal(object logMessage)
    {
      if (IsFatalEnabled)
        _log.Fatal(JsonConvert.SerializeObject(logMessage));
    }

    public void Error(object logMessage)
    {
      if (IsErrorEnabled)
        _log.Error(JsonConvert.SerializeObject(logMessage));
    }
  }
}
