using ErrorLoggingMiddleware__real_world_scenario.Models;
using ErrorLoggingMiddleware__real_world_scenario;

namespace ErrorLoggingMiddleware_real_world_scenario.Middlewares
{
    public class ErrorLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorLoggingMiddleware> _logger;
        private readonly IServiceProvider _serviceProvider;

        public ErrorLoggingMiddleware(RequestDelegate next, ILogger<ErrorLoggingMiddleware> logger, IServiceProvider serviceProvider)
        {
            _next = next;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Resolve ApplicationDbContext per request scope
                using (var scope = _serviceProvider.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                    // Log the exception to the database
                    var errorLog = new ErrorLog
                    {
                        RequestPath = context.Request.Path,
                        ErrorMessage = ex.Message,
                        StackTrace = ex.StackTrace,
                        LogTime = DateTime.UtcNow
                    };

                    dbContext.ErrorLogs.Add(errorLog);
                    await dbContext.SaveChangesAsync();
                }

                // Re-throw the exception to be caught by the global error handler
                throw;
            }
        }
    }
}
