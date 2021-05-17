using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookPS02.Utils
{
    public class CustomFilterAttributes : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var result = (PageResult)context.Result;
            result.ViewData["ipAddress"] = context.HttpContext.Connection.RemoteIpAddress.ToString();
            await next.Invoke();
        }

    }

}
