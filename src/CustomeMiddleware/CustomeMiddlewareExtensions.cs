using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CustomeMiddleware
{
    public static class CustomeMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMidware>();
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
