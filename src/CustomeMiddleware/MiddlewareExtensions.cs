using CustomeMiddlewarem;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CustomeMiddleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMyCustomeMiddleware(this IApplicationBuilder builder, ILoggerFactory loggerfactory, IConfigurationRoot config)
        {
            return builder.UseMiddleware<CustomMidware>(config);
        }

        //    public void ConfigureLogMiddleware(IApplicationBuilder app,
        //ILoggerFactory loggerfactory)
        //    {
        //        loggerfactory.AddConsole(minLevel: LogLevel.Information);

        //        app.UseRequestLogger();

        //        app.Run(async context =>
        //        {
        //            await context.Response.WriteAsync("Hello from " + _environment);
        //        });
        //    }
    }
}