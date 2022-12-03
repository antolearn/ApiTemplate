using Api.ApiResponses;
using System.Net;

namespace Api.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionHandlerMiddleware> logger;
        private readonly IWebHostEnvironment env;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger, IWebHostEnvironment env)
        {
            this.next = next;
            this.logger = logger;
            this.env = env;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next (context);   
            }
            catch (Exception ex)
            {
                ApiErrorResponse response;
                HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
                String message;
                var exceptionType = ex.GetType();
                //switch(exceptionType)
                //{
                    
                //}

                if (exceptionType == typeof(UnauthorizedAccessException))
                {
                    statusCode = HttpStatusCode.Forbidden;
                    message = "You are not authorized";
                }
                else
                {
                    statusCode = HttpStatusCode.InternalServerError;
                    message = "Unknown error has occured";
                }

                if(env.IsDevelopment())
                {
                    response = new ApiErrorResponse((int)statusCode, ex.Message, ex.StackTrace.ToString());
                } else
                {
                    response = new ApiErrorResponse((int)statusCode, message);

                }

                logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)statusCode;
                context.Response.ContentType = "application/json";                
                await context.Response.WriteAsync(response.ToString());
            }
        }
    }
}
