using System.ComponentModel.DataAnnotations;

namespace ITBees.ConsoleLogger;

public class ConsoleLog
{
    [Key]
    public long Id { get; set; }
    public string JSONData { get; set; }
    public DateTime LocalDateTime { get; set; }
    public DateTime ReceivedDateTime { get; set; }
}