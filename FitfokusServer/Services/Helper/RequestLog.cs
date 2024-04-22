namespace FitfokusServer.Services.Helper;


public class RequestLog
{
    public string? RequestType { get; set; }
    public DateTime Date { get; set; }
    public string? Path { get; set; }
    public int? StatusCode { get; set; }
    public string? Stuff { get; set; }
}