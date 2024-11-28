using ITBees.ConsoleLogger.Controllers;

namespace ITBees.ConsoleLogger.Interfaces;

public interface IDebugLogger
{
    void Save(DebugRequestIm debugRequestIm, string clientIp);
    void Delete(DebugConsoleLogDm debugConsoleLogDm);
}