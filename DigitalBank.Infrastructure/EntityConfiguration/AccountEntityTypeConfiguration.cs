using DigitalBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalBank.Infrastructure.EntityConfiguration;

public class AccountEntityTypeConfiguration : BaseEntityTypeConfiguration<Account>
{
    public override void Configure(EntityTypeBuilder<Account> builder)
    {
        base.Configure(builder);

        builder.ToTable("accounts");

        builder.Property(a => a.Balance)
            .HasColumnName("balance")
            .HasColumnType("decimal(18, 2)")
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(a => a.ClientId)
            .HasColumnName("client_id");

        builder.HasOne(a => a.Client)
            .WithMany(c => c.Accounts)
            .HasForeignKey(a => a.ClientId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}