namespace Common.ExceptionHandler.Middleware
{
    using Common.ExceptionHandler.Exceptions;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Net;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="next"></param>
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// On Invoke
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                response.StatusCode = error
                switch
                {
                    BadRequestException => (int)HttpStatusCode.BadRequest, // Bad request error
                    ForbiddenException => (int)HttpStatusCode.Forbidden, // Forbidden error
                    NotFoundException => (int)HttpStatusCode.NotFound, // Not found exception
                    InternalException => (int)HttpStatusCode.InternalServerError, // Internal exception
                    UnauthorizedException => (int)HttpStatusCode.Unauthorized, // Unauthorized exception
                    _ => (int)HttpStatusCode.InternalServerError, // Unhandled error
                };

                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}
