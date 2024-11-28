using ITBees.ConsoleLogger.Interfaces;
using ITBees.Interfaces.Repository;
using ITBees.RestfulApiControllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ITBees.ConsoleLogger.Controllers;

public class DebugConsoleLogsController : RestfulControllerBase<DebugConsoleLogsController>
{
    private readonly IDebugConsoleLogs _debugConsoleLogs;

    public DebugConsoleLogsController(ILogger<DebugConsoleLogsController> logger, IDebugConsoleLogs debugConsoleLogs) : base(logger)
    {
        _debugConsoleLogs = debugConsoleLogs;
    }

    [HttpGet]
    public IActionResult Get(bool onlyPersisted, string? authKey, int? page, int? pageSize, string sortColumn, SortOrder? sortOrder)
    {
        return ReturnOkResult(() => _debugConsoleLogs.Get(onlyPersisted, new SortOptions(page, pageSize, sortColumn, sortOrder), authKey));
    }
}