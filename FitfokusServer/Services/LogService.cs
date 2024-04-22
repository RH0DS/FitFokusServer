using FitfokusServer.Services.Helper;

namespace FitfokusServer.Services;

public class LogService
{
    private readonly RequestDelegate _next;
    private readonly IHostEnvironment _environment;
    private readonly string _logFilePath;

    public LogService(RequestDelegate next, IHostEnvironment environment)
    {
        _next = next;
        _environment = environment;
        _logFilePath = Path.Combine(_environment.ContentRootPath, "EventLog.txt");
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var request = context.Request;

        var requestLog = new RequestLog
        {
            RequestType = request.Method,
            Date = DateTime.UtcNow,
            Path = request.Path,
            Stuff = request.Body.ToString()
        };

        var originalBodyStream = context.Response.Body;
        using var responseBody = new MemoryStream();
        context.Response.Body = responseBody;

        try
        {
            await _next(context);

            requestLog.StatusCode = context.Response.StatusCode;
            responseBody.Seek(0, SeekOrigin.Begin);
            await responseBody.CopyToAsync(originalBodyStream);
        }
        finally
        {
            await LogMessageAsync(requestLog);
        }
    }
    private async Task LogMessageAsync(RequestLog requestLog)
    {
        var logMessage = $"{requestLog.RequestType} {requestLog.Path} {requestLog.StatusCode} {requestLog.Date} {requestLog.Stuff}\n";
        await File.AppendAllTextAsync(_logFilePath, logMessage);
    }
}