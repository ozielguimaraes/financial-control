using FinancialControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialControl.Infra.Data.Mappings
{
    public class CashierAccountMap : IEntityTypeConfiguration<CashierAccount>
    {
        public void Configure(EntityTypeBuilder<CashierAccount> builder)
        {
            builder.HasKey(c => c.CashierAccountId);
            builder.Property(c => c.CashierAccountId)
                .HasColumnName("Id");
        }
    }
}
