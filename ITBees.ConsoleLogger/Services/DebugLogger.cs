using ITBees.ConsoleLogger.Controllers;
using ITBees.ConsoleLogger.Interfaces;
using ITBees.ConsoleLogger.Services.Models;
using ITBees.Interfaces.Repository;
using ITBees.UserManager.Interfaces;

namespace ITBees.ConsoleLogger.Services;

public class DebugLogger : IDebugLogger
{
    private readonly IWriteOnlyRepository<ConsoleLog> _consoleLogRwRepo;
    private readonly IAspCurrentUserService _aspCurrentUserService;

    public DebugLogger(IWriteOnlyRepository<ConsoleLog> consoleLogRwRepo, IAspCurrentUserService aspCurrentUserService)
    {
        _consoleLogRwRepo = consoleLogRwRepo;
        _aspCurrentUserService = aspCurrentUserService;
    }
    public void Save(DebugRequestIm debugRequestIm, string clientIp)
    {
        var cu = _aspCurrentUserService.GetCurrentUser();

        _consoleLogRwRepo.InsertData(new ConsoleLog()
        {
            JSONData = debugRequestIm.JSONData,
            LocalDateTime = debugRequestIm.LocalDateTime,
            ReceivedDateTime = DateTime.Now,
            UserAccountGuid = cu?.Guid,
            Ip = clientIp
        });
    }

    public void Delete(DebugConsoleLogDm debugConsoleLogDm)
    {
        foreach (var logsId in debugConsoleLogDm.LogsIds)
        {
            _consoleLogRwRepo.DeleteData(x => x.Id == logsId);
        }
    }
}