using Udemy_1.CustomMiddlewares;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();


app.UsePostHandllerMiddleware();

app.Run();
