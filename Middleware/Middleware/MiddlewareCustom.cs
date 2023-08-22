using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MiddlewareCustom
    {
        private readonly RequestDelegate _next;

        public MiddlewareCustom(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if(context.Request.Path == "/" && context.Request.Method == "POST")
            {
                StreamReader reader = new StreamReader(context.Request.Body);
                string body = await reader.ReadToEndAsync();

                Dictionary<string,StringValues> queryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);
                string? email = null, pass = null;
                if (queryDict.ContainsKey("email") && queryDict.ContainsKey("pass"))
                {
                    email = Convert.ToString(queryDict["email"][0]);
                    pass = Convert.ToString(queryDict["pass"][0]);
                }
                else
                {
                    await context.Response.WriteAsync("Invalid Input for Email or Pass");
                }

                if (string.IsNullOrEmpty(email) == false && string.IsNullOrEmpty(pass) == false)
                {
                    string validEmail = "admin@example.com", validPass = "admin1234";

                    if (email == validEmail && pass == validPass)
                    {
                        context.Response.StatusCode = 200;
                        await context.Response.WriteAsync("Successful Login");
                    }
                    else
                    {
                        context.Response.StatusCode = 400;
                        await context.Response.WriteAsync("Invalid Login");
                    }
                }
                else
                {
                    await _next(context);
                }
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareCustomExtensions
    {
        public static IApplicationBuilder UseMiddlewareCustom(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareCustom>();
        }
    }
}
