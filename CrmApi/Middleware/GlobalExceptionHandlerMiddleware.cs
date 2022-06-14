using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Serilog;
using System.Threading.Tasks;

namespace Antra.CrmAPI.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerFactory _loggerFactory;
        public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _loggerFactory = loggerFactory;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            Log.Information("This project stated execution");
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                //var ex = httpContext.Features.Get<IExceptionHandlerFeature>();
                if (ex != null)
                {

                    //  var _logger = _loggerFactory.CreateLogger<GlobalExceptionHandlerMiddleware>();
                    // _logger.LogError(ex.StackTrace);

                    Log.Error(ex, "Exception has been handled");

                    await httpContext.Response.WriteAsync(ex.Message);
                }
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class GlobalExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionHandlerMiddleware>();
        }
    }
}