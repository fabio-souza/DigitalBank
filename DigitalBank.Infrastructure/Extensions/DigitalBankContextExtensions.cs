using DigitalBank.Infrastructure;
using DigitalBank.Domain.Interfaces;
using DigitalBank.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore; // UserMysql
using Microsoft.Extensions.DependencyInjection; // IServiceCollection

namespace DigitalBank.Infrastructure.Extensions;

public static class NorthwindContextExtensions
{
    /// <summary>
    /// Adds NorthwindContext to the specified IServiceCollection. Uses the SqlServer database provider.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="connectionString">Set to override the default.</param>
    /// <returns>An IServiceCollection that can be used to add more services.</returns>
    public static IServiceCollection AddDigitalBankContext(
      this IServiceCollection services,
      string connectionString = 
            "Data Source=mysql01-dev-fabio-rs.mysql.database.azure.com;" +
            "Initial Catalog=digital_bank;" +
            "Username=digital_bank;" +
            "Password=cacce5QuacOw|Orjyep@;" +
            "SslMode=Required")
    {
        var serverVersion = new MySqlServerVersion(new Version(8, 0));

        services.AddDbContext<DigitalBankContext>(options =>
        {
            options.UseMySql(connectionString, serverVersion);

            options.LogTo(Console.WriteLine,
          new[] { Microsoft.EntityFrameworkCore
          .Diagnostics.RelationalEventId.CommandExecuting });
        });

        return services;
    }

    public static IServiceCollection AddDigitalBankRepositories(this IServiceCollection services)
    {
      services.AddTransient<IClientRepository, ClientRepository>();

      return services;
    }
}
