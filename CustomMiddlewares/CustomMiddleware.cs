namespace Udemy_1.CustomMiddlewares
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("CustomMiddleware Before next()");
            await next(context);
            await context.Response.WriteAsync("CustomMiddleware After next()");
        }
    }
}
