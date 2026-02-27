namespace TMS_2_with_middleware.Middleware
{
    public class SampleMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Console.WriteLine("Separate middleware test");
            await next(context);
            Console.WriteLine("end of middleware");
        }
    }

    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<SampleMiddleware>();
        }
    }
}
