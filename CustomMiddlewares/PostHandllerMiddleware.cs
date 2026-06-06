using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Udemy_1.CustomMiddlewares
{
    public class PostHandllerMiddleware
    {
        private readonly RequestDelegate _next;

        public PostHandllerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (!HttpMethods.IsPost(httpContext.Request.Method))
            {
                await _next(httpContext);
                return;
            }

            var email = httpContext.Request.Form["email"].ToString();
            var password = httpContext.Request.Form["password"].ToString();

            if (email != "admin@example.com")
            {
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                await httpContext.Response.WriteAsync("Invalid login");
            }
            else if (password != "admin1234")
            {
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                await httpContext.Response.WriteAsync("Invalid login");
            }
            else
            {
                httpContext.Response.StatusCode = StatusCodes.Status200OK;
                await httpContext.Response.WriteAsync("Successful login");
            }
        }
    }

    public static class PostHandllerMiddlewareExtensions
    {
        public static IApplicationBuilder UsePostHandllerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PostHandllerMiddleware>();
        }
    }
}