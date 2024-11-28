using ITBees.Interfaces.Repository;

namespace ITBees.ConsoleLogger;

public class DebugLogger : IDebugLogger
{
    private readonly IWriteOnlyRepository<ConsoleLog> _consoleLogRwRepo;

    public DebugLogger(IWriteOnlyRepository<ConsoleLog> consoleLogRwRepo)
    {
        _consoleLogRwRepo = consoleLogRwRepo;
    }
    public void Save(DebugRequestIm debugRequestIm)
    {
        _consoleLogRwRepo.InsertData(new ConsoleLog()
        {
            JSONData = debugRequestIm.JSONData,
            LocalDateTime = debugRequestIm.LocalDateTime,
            ReceivedDateTime = DateTime.Now
        });
    }
}