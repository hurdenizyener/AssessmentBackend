using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class InvoiceHeaderConfiguration : IEntityTypeConfiguration<InvoiceHeader>
    {
        public void Configure(EntityTypeBuilder<InvoiceHeader> builder)
        {
            builder.ToTable("InvoiceHeaders").HasKey(p => p.InvoiceId);
            builder.Property(p => p.InvoiceId).HasColumnName("InvoiceId").HasMaxLength(25).IsRequired();
            builder.Property(p => p.SenderTitle).HasColumnName("SenderTitle").HasMaxLength(150).IsRequired();
            builder.Property(p => p.ReceiverTitle).HasColumnName("ReceiverTitle").HasMaxLength(150).IsRequired();
            builder.Property(p => p.Date).HasColumnName("Date");

        }
    }
}
