using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooklistRazorV1.CustomMiddlewares
{
    public class EmployeeLocationMiddleware
    {
        private readonly RequestDelegate next;
        private readonly EmployeeLocationOptions options;

        public EmployeeLocationMiddleware(RequestDelegate nextDelegate,IOptions<EmployeeLocationOptions> opts)

        {
            next = nextDelegate;
            options = opts.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            if(context.Request.Path=="/EmployeeLocation")
            {
                await context.Response.WriteAsync($"{options.CityName}, {options.CountryName}");

            }
            else
            {
                await next(context);
            }
        }
    }
}
