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

    // Created a static class to extend the "app" in program.cs
    public static class CustomMiddlewareJunior  
    {
        //            ხოლო აპი ამის შვილობილია
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder app)
        {
            // ეს აბრუნებს app -ს
            return app.UseMiddleware<CustomMiddleware>();
        }
    }
}
