using ITBees.ConsoleLogger.Controllers;
using ITBees.ConsoleLogger.Interfaces;
using ITBees.ConsoleLogger.Services.Models;
using ITBees.Interfaces.Platforms;
using ITBees.Interfaces.Repository;
using ITBees.UserManager.Interfaces;

namespace ITBees.ConsoleLogger.Services;

public class DebugConsoleLogs : IDebugConsoleLogs
{
    private readonly IReadOnlyRepository<ConsoleLog> _consoleLogRoRepo;
    private readonly IWriteOnlyRepository<ConsoleLog> _consoleLogRwRepo;
    private readonly IAspCurrentUserService _aspCurrentUserService;
    private readonly IPlatformSettingsService _platformSettingsService;

    public DebugConsoleLogs(
        IReadOnlyRepository<ConsoleLog> consoleLogRoRepo,
        IWriteOnlyRepository<ConsoleLog> consoleLogRwRepo, 
        IAspCurrentUserService aspCurrentUserService, 
        IPlatformSettingsService platformSettingsService)
    {
        _consoleLogRoRepo = consoleLogRoRepo;
        _consoleLogRwRepo = consoleLogRwRepo;
        _aspCurrentUserService = aspCurrentUserService;
        _platformSettingsService = platformSettingsService;
    }
    public PaginatedResult<DebugConsoleLogVm> Get(bool onlyPersisted, SortOptions sortOptions, string? authKey)
    {
        if (_aspCurrentUserService.CurrentUserIsPlatformOperator() == false && string.IsNullOrEmpty(authKey)) { throw new UnauthorizedAccessException(); }
        if(_aspCurrentUserService.CurrentUserIsPlatformOperator() == false  && _platformSettingsService.GetSetting("platformAuthKey") != authKey) { throw new UnauthorizedAccessException(); }
        
        if (onlyPersisted)
        {
            return _consoleLogRoRepo.GetDataPaginated(x => x.Persist, sortOptions).MapTo(x => new DebugConsoleLogVm(x));
        }
        else
        {
            return _consoleLogRoRepo.GetDataPaginated(x => true, sortOptions).MapTo(x => new DebugConsoleLogVm(x));
        }
        
        
    }

    public void Update(DebugConsoleLogUm debugConsoleLogUm)
    {
        _consoleLogRwRepo.UpdateData(x => x.Id == debugConsoleLogUm.Id, x =>
        {
            x.Analyzed = debugConsoleLogUm.Analyzed;
            x.Persist = debugConsoleLogUm.Persist;
        });
    }
}