using FinancialControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialControl.Infra.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryId);
            builder.Property(c => c.CategoryId)
                .HasColumnName("Id");

            builder.Property(c => c.CategoryId)
                .IsRequired();

            builder.Property(c => c.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.HasMany(p => p.Transactions)
                .WithOne(c => c.Category)
                .HasForeignKey(x => x.CategoryId);

            builder.HasOne(p => p.SubCategory)
                .WithMany()
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
