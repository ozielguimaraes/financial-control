using FinancialControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialControl.Infra.Data.Mappings
{
    public class WithdrawMap : IEntityTypeConfiguration<Withdraw>
    {
        public void Configure(EntityTypeBuilder<Withdraw> builder)
        {
            builder.HasKey(c => c.WithdrawId);
            builder.Property(c => c.WithdrawId)
                .HasColumnName("Id");
        }
    }
}
