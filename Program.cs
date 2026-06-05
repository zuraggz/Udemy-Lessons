var builder = WebApplication.CreateBuilder(args);
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

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("!");
});

app.Run();
