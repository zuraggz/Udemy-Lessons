using Udemy_1.CustomMiddlewares;

var builder = WebApplication.CreateBuilder(args);
// Need to use DI to access custom middleware
builder.Services.AddTransient<CustomMiddleware>();
var app = builder.Build();


app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Connor vs ");
    await next(context);
});

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Max");
    await next(context);
});

// Auto invoke Method in there
app.UseMiddleware<CustomMiddleware>();

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("!");
});

app.Run();
