using Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCutomMiddleware>();
var app = builder.Build();

app.UseMiddlewareCustom();

app.Run();
