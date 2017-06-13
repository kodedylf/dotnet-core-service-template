using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System.IO;
using System.Threading.Tasks;

namespace dotnet_core_service_template
{
    public class LoggingFilter : IAsyncResourceFilter
    {
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            Log.Information($"{context.HttpContext.Request.Method} {context.HttpContext.Request.Path}");

            var originalBodyStream = context.HttpContext.Response.Body;
            var stream = new MemoryStream();
            context.HttpContext.Response.Body = stream;

            await next();

            stream.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(stream);
            Log.Information($"{context.HttpContext.Response.StatusCode} {sr.ReadToEnd()}");

            stream.Seek(0, SeekOrigin.Begin);
            stream.CopyTo(originalBodyStream);
            context.HttpContext.Response.Body = originalBodyStream;
        }
    }
}
