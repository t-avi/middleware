using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Lab_2_Core
{
    public class RoutingMiddleware
    {
        private readonly RequestDelegate _next;
        public RoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string path = context.Request.Path.Value.ToLower();
            if (path == "/index")
            {
                var link = File.ReadAllText(@"D:\Таня\Lab_2_Core\Lab_2_Core\wwwroot\Index.html");
                await context.Response.WriteAsync(link);
            }
            else if (path == "/about")
            {
                await context.Response.WriteAsync("<h1>About</h1> <br> <a href='/index'>Back to homepage</a>");
            }
            else if (path == "/contact")
            {
                await context.Response.WriteAsync("<h1>Contact</h1> <br> <a href='/index'>Back to homepage</a>");
            }
            else
            {
                context.Response.StatusCode = 404;
            }
        }
    }
}
