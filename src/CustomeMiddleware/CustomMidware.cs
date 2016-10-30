using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace CustomeMiddlewarem
{
    public class CustomMidware
    {
        private readonly RequestDelegate _next;
        private static string EmailFrom;
        private static string EmailTo;
        private readonly IConfigurationRoot _config;

        public CustomMidware(IConfigurationRoot config, RequestDelegate next)
        {
            _config = config;
            EmailFrom = _config["ErrorSetUp:Email:Form"];
            //(_config["ConnectionStrings:WorldContextConnection"]
            EmailTo = _config["ErrorSetUp:Email:To"];
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            Console.WriteLine($"Request for {httpContext.Request.Path} received ({httpContext.Request.ContentLength ?? 0} bytes)");

            await _next.Invoke(httpContext);
        }

        //public static void SetBasePath(string basePath)
        //{
        //    _basepath = basePath;
        //}

        //public static void AddJsonFile(string fileName)
        //{
        //    _filepath = fileName;
        //}
    }
}