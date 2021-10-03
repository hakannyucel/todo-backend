using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Extensions
{
  public class ExceptionMiddleware
  {
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
      try
      {
        await _next(context);
      }
      catch (Exception e)
      {
        await HandleExceptionAsync(context, e);
      }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception e)
    {
      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

      return context.Response.WriteAsync(new ErrorDetails
      {
        StatusCode = context.Response.StatusCode,
        Message = "Interval Server Error"
      }.ToString());
    }
  }
}
