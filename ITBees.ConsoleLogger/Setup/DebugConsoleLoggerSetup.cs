using ITBees.FAS.Setup;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ITBees.ConsoleLogger.Setup;

public class DebugConsoleLoggerSetup : IFasDependencyRegistration
{
    public void Register(IServiceCollection services, IConfigurationRoot configurationRoot)
    {
        services.AddScoped<IDebugLogger, DebugLogger>();
    }
}

public class DbModelBuilder
{
    public static void Register(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ConsoleLog>().HasKey(x => x.Id);
    }
}