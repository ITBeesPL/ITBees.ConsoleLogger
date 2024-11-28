using System.ComponentModel.DataAnnotations;
using ITBees.Models.Users;

namespace ITBees.ConsoleLogger.Services.Models;

public class ConsoleLog
{
    [Key]
    public long Id { get; set; }
    public string JSONData { get; set; }
    public DateTime LocalDateTime { get; set; }
    public DateTime ReceivedDateTime { get; set; }
    public UserAccount UserAccount { get; set; }
    public Guid? UserAccountGuid { get; set; }
    public string Ip { get; set; }
    public bool Analyzed { get; set; }
    public bool Persist { get; set; }
}