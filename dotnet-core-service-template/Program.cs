using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace dotnet_core_service_template
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel(options =>
                {
                    options.UseHttps("certificates/template.pfx", "template");
                })
                .UseUrls("https://*:14114")
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
