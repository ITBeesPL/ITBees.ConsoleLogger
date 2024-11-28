using ITBees.ConsoleLogger.Controllers;
using ITBees.ConsoleLogger.Interfaces;
using ITBees.ConsoleLogger.Services.Models;
using ITBees.Interfaces.Repository;

namespace ITBees.ConsoleLogger.Services;

public class DebugConsoleLogs : IDebugConsoleLogs
{
    private readonly IReadOnlyRepository<ConsoleLog> _consoleLogRoRepo;
    private readonly IWriteOnlyRepository<ConsoleLog> _consoleLogRwRepo;

    public DebugConsoleLogs(
        IReadOnlyRepository<ConsoleLog> consoleLogRoRepo,
        IWriteOnlyRepository<ConsoleLog> consoleLogRwRepo)
    {
        _consoleLogRoRepo = consoleLogRoRepo;
        _consoleLogRwRepo = consoleLogRwRepo;
    }
    public PaginatedResult<DebugConsoleLogVm> Get(bool onlyPersisted, SortOptions sortOptions)
    {
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