using System.Runtime.CompilerServices;

namespace Middleware
{
    public class MyCutomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("My Custom Middleware - Starts\n");
            await next(context);
            await context.Response.WriteAsync("My Custom Middleware - Ends\n");
        }
    }
    public class MyCutomMiddleware2 : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("My Custom Middleware 2  - Starts\n");
            await next(context);
            await context.Response.WriteAsync("My Custom Middleware 2 - Ends\n");
        }
    }

    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder app)
        {
           return app.UseMiddleware<MyCutomMiddleware>();
        }
    }
}
