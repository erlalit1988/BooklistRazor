using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooklistRazorV1.CustomMiddlewares
{
    public class RequestQueryStringMiddleware
    {
        private readonly RequestDelegate next;

        public RequestQueryStringMiddleware()
        {
        }

        public RequestQueryStringMiddleware(RequestDelegate nextRequest)
        {
            next= nextRequest;
        }
        public async Task Invoke(HttpContext context)
        {
            if(context.Request.Method==HttpMethods.Get 
                 &&context.Request.Query["isCertified"] =="true")
            {
                await context.Response.WriteAsync("Message from class-based Middleware \n");
            }
            if (next != null)
            {
                await next(context);
            }
        }
    }
}
