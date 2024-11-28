using ITBees.ConsoleLogger.Controllers;
using ITBees.Interfaces.Repository;
using Org.BouncyCastle.Asn1.BC;

namespace ITBees.ConsoleLogger.Interfaces;

public interface IDebugConsoleLogs
{
    PaginatedResult<DebugConsoleLogVm> Get(bool onlyPersisted, SortOptions sortOptions, string? authKey);
    void Update(DebugConsoleLogUm debugConsoleLogUm);
}