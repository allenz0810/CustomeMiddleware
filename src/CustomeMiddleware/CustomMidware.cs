using CustomeMiddleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CustomeMiddlewarem
{
    public class CustomMidware
    {
        private readonly RequestDelegate _next;
        private static Email _email;
        private readonly IConfigurationRoot _config;

        public CustomMidware(ILoggerFactory loggerfactory, IConfigurationRoot config, RequestDelegate next)
        {
            _config = config;
            _email.From = _config["ErrorSetUp:Email:Form"];
            //(_config["ConnectionStrings:WorldContextConnection"]
            _email.To = _config["ErrorSetUp:Email:To"];
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //await httpContext.Response.WriteAsync("Hello from CustomMidware");
            Console.WriteLine($"Request for {httpContext.Request.Path} received ({httpContext.Request.ContentLength ?? 0} bytes)");
            //await httpContext.Response.WriteAsync("Good bye from CustomMidware");

            await _next.Invoke(httpContext);
        }
    }

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMyCustomeMiddleware(this IApplicationBuilder builder, ILoggerFactory loggerfactory, IConfigurationRoot config)
        {
            return builder.UseMiddleware<CustomMidware>(config);
        }
    }
}