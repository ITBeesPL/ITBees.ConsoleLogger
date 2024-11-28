using ITBees.ConsoleLogger.Services.Models;

namespace ITBees.ConsoleLogger.Interfaces;

public class DebugConsoleLogVm
{
    public DebugConsoleLogVm()
    {
        
    }

    public DebugConsoleLogVm(ConsoleLog x)
    {
        Id = x.Id;
        JSONData = x.JSONData;
        LocalDateTime = x.LocalDateTime;
        ReceivedDateTime = x.ReceivedDateTime;
        UserEmail = x.UserAccount?.Email;
        Ip = x.Ip;
        Analyzed = x.Analyzed;
    }

    public long Id { get; set; }
    public string JSONData { get; set; }
    public DateTime LocalDateTime { get; set; }
    public DateTime ReceivedDateTime { get; set; }
    public string? UserEmail { get; set; }
    public string Ip { get; set; }
    public bool Analyzed { get; set; }
}