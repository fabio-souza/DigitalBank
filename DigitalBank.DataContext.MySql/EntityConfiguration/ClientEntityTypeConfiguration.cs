using DigitalBank.EntityModels;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalBank.DataContext.MySql.EntityConfiguration;

public class ClientEntityTypeConfiguration : BaseEntityTypeConfiguration<Client>
{
    public override void Configure(EntityTypeBuilder<Client> builder)
    {
        base.Configure(builder);

        builder.ToTable("clients");

        builder.Property(c => c.FirstName)
            .HasColumnName("firstname")
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(c => c.LastName)
            .HasColumnName("lastname")
            .HasColumnType("varchar(100)")
            .IsRequired();
    }
}