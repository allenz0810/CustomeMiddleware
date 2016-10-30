﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace CustomeMiddlewarem
{
    public class CustomMidware
    {
        private readonly RequestDelegate _next;
        private readonly static string _basepath = "";
        private readonly static string _filepath = "";
        private readonly IConfigurationRoot _config;
        public CustomMidware(IConfigurationRoot config, RequestDelegate next)
        {
            _config = config;
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
