using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class InvoiceLineConfiguration : IEntityTypeConfiguration<InvoiceLine>
    {
        public void Configure(EntityTypeBuilder<InvoiceLine> builder)
        {
            builder.ToTable("InvoiceLines")
                .HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .IsRequired();
            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(p => p.Quantity)
                .HasColumnName("Quantity")
                .IsRequired();
            builder.Property(p => p.UnitCode)
                .HasColumnName("UnitCode")
                .HasMaxLength(10)
                .IsRequired();
            builder.Property(p => p.UnitPrice)
                .HasColumnName("UnitPrice")
                .IsRequired();

        }
    }
}
