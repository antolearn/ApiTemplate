using Api.Middlewares;
using System.Net;

namespace Api.Startup
{
    public static class ExceptionHandlerConfiguration
    {
        public static WebApplication ConfigureExceptionHandler(this WebApplication app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            return app;
        }
        
        //public static WebApplication ConfigureExceptionHandler(this WebApplication app, IWebHostEnvironment env )
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }
        //    app.UseExceptionHandler(
        //        options =>
        //        {
        //            options.Run(
        //                async context =>
        //                {
        //                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        //                    var ex = context.Features.Get<IExceptionHandlerFeature>();
        //                    if (ex != null)
        //                    {
        //                        await context.Response.WriteAsync(ex.Error.Message);
        //                    }
        //                }
        //                );
        //        }
        //        );
        //    return app;
        //}

    }
}
