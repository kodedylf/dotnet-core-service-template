using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_core_service_template
{
    public class LoggingFilter : IAsyncResourceFilter
    {
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            var request = context.HttpContext.Request.Method + " " + context.HttpContext.Request.Path;

            var originalBodyStream = context.HttpContext.Response.Body;
            var stream = new MemoryStream();
            context.HttpContext.Response.Body = stream;

            await next();

            stream.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(stream);
            var response = context.HttpContext.Response.StatusCode + " " + sr.ReadToEnd();
            Log.Information(request + "\r\n" + response);

            stream.Seek(0, SeekOrigin.Begin);
            stream.CopyTo(originalBodyStream);
            context.HttpContext.Response.Body = originalBodyStream;
        }
    }
}
