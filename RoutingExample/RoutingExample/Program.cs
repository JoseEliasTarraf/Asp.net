var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//enable routing
app.UseRouting();

//creating endpoints
app.UseEndpoints(endpoints =>
{
    string[] countries =new string[4];
    countries[0] = "Uruguay"; 
    countries[1] = "Brazil"; 
    countries[2] = "Paraguay"; 
    countries[3] = "Spain"; 
    endpoints.MapGet("countries", async context =>
    {
        context.Response.StatusCode = 200;
        if(context.Response.StatusCode == 200)
        {
            int p = 1;
            for (int i = 0; i < countries.Length; i++)
            {
                await context.Response.WriteAsync(p+"."+countries[i]+"\n");
                p++;
            }
        }
    });
    endpoints.MapGet("countries/{id:int}", async context =>
    {
        context.Response.StatusCode = 200;
        if(context.Response.StatusCode == 200)
        {
            if (context.Request.RouteValues.ContainsKey("id"))
            {
                context.Response.StatusCode = 200;

                int id = Convert.ToInt32(context.Request.RouteValues["id"]);

                await context.Response.WriteAsync(countries[id]);
            }
            
        }
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync($"Request received at " +
        $"{context.Request.Path}");
});

app.Run();
