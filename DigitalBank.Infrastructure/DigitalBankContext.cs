using DigitalBank.Infrastructure.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using DigitalBank.Domain.Entities;

namespace DigitalBank.Infrastructure;

public class DigitalBankContext : DbContext
{
    public DigitalBankContext()
    {

    }

    public DigitalBankContext(DbContextOptions<DigitalBankContext> options)
    : base(options)
    {
    }
    public DbSet<Client> Clients { get; set; }

    public DbSet<Account> Accounts { get; set; }

    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString =
            "Data Source=mysql01-dev-fabio-rs.mysql.database.azure.com;" +
            "Initial Catalog=digital_bank;" +
            "Username=digital_bank;" +
            "Password=cacce5QuacOw|Orjyep@;" +
            "SslMode=Required";

        var serverVersion = new MySqlServerVersion(new Version(8, 0));

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ClientEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TransactionEntityTypeConfiguration());
    }
}