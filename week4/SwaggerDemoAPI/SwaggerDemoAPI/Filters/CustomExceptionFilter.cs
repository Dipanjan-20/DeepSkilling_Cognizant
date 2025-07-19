using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SwaggerDemoAPI.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string logPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);

            string logFile = Path.Combine(logPath, "error.log");
            File.AppendAllText(logFile, $"[{DateTime.Now}] {context.Exception.Message}\n");

            context.Result = new ObjectResult("An internal server error occurred.")
            {
                StatusCode = 500
            };
        }
    }
}
