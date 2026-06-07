using Udemy_1.CustomMiddlewares;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();


app.Map("files/{filename}.{extension}", async context =>
{
    string? fileName=Convert.ToString(context.Request.RouteValues["filename"]);
    string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
    await context.Response.WriteAsync($"In files, file:{fileName}.{extension}");
});

app.Map("employee/developers/{name}", async context =>
{
    string? name = Convert.ToString(context.Request.RouteValues["name"]);
    await context.Response.WriteAsync($"Hi, {name}");
});


app.MapFallback(async (context) =>
{
    await context.Response.WriteAsync("Any other");
});

app.Run();
