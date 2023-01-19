using FinancialControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialControl.Infra.Data.Mappings
{
    public class TransactionMap : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(c => c.TransactionId);
            builder.Property(c => c.TransactionId)
                .HasColumnName("Id");

            builder.Property(c => c.CategoryId)
                .IsRequired();

            builder.Property(c => c.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(c => c.Value)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.HasOne(c => c.Category)
                .WithMany(c => c.Transactions)
                .HasForeignKey(x => x.CategoryId);

            builder.HasOne(c => c.CashierAccount);
        }
    }
}
