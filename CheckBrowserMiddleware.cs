using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wangkanai.Detection.Models;
using Wangkanai.Detection.Services;

namespace AddressBookPS02
{
    public class CheckBrowserMiddleware
    {
        private readonly RequestDelegate _next;
        public CheckBrowserMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public Task Invoke(HttpContext context, IDetectionService detection)
        {
            if (detection.Browser.Name == Browser.InternetExplorer || detection.Browser.Name == Browser.Edge)
            {
                context.Response.WriteAsync("Przegladarka nie jest obslugiwana");
                return _next(context);
            }
            else
            {
                
                return _next(context);
            }
        }
    }
}
