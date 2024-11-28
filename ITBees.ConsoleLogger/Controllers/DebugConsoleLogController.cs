using ITBees.ConsoleLogger.Interfaces;
using ITBees.RestfulApiControllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ITBees.ConsoleLogger.Controllers;

public class DebugConsoleLogController : RestfulControllerBase<DebugConsoleLogController>
{
    private readonly IDebugConsoleLogs _debugConsoleLogs;
    private readonly IDebugLogger _debugLogger;

    public DebugConsoleLogController(ILogger<DebugConsoleLogController> logger, 
        IDebugConsoleLogs debugConsoleLogs,
        IDebugLogger debugLogger) : base(logger)
    {
        _debugConsoleLogs = debugConsoleLogs;
        _debugLogger = debugLogger;
    }

    [HttpPost]
    public IActionResult Post([FromBody] DebugConsoleLogUm debugConsoleLogUm)
    {
        return ReturnOkResult(() => _debugConsoleLogs.Update(debugConsoleLogUm));
    }

    [HttpDelete]
    public IActionResult Del([FromBody] DebugConsoleLogDm debugConsoleLogDm)
    {
        return ReturnOkResult(() => _debugLogger.Delete(debugConsoleLogDm));
    }
}