// <auto-generated />
using System;
using FinancialControl.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinancialControl.Infra.Data.Migrations
{
    [DbContext(typeof(MainContext))]
    partial class MainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FinancialControl.Domain.Entities.Cashier", b =>
                {
                    b.Property<long>("CashierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CashierId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CashierId");

                    b.ToTable("Cashiers");
                });

            modelBuilder.Entity("FinancialControl.Domain.Entities.CashierAccount", b =>
                {
                    b.Property<long>("CashierAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CashierAccountId"));

                    b.Property<long>("CashierId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CashierAccountId");

                    b.HasIndex("CashierId");

                    b.ToTable("CashierAccounts");
                });

            modelBuilder.Entity("FinancialControl.Domain.Entities.Category", b =>
                {
                    b.Property<long>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SubCategoryId")
                        .HasColumnType("bigint");

                    b.HasKey("CategoryId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("FinancialControl.Domain.Entities.Transaction", b =>
                {
                    b.Property<long>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("TransactionId"));

                    b.Property<long>("CashierAccountId")
                        .HasColumnType("bigint");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Receipt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("TransactionId");

                    b.HasIndex("CashierAccountId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("FinancialControl.Domain.Entities.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UserId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FinancialControl.Domain.Entities.Withdraw", b =>
                {
                    b.Property<long>("WithdrawId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("WithdrawId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WithdrawId");

                    b.ToTable("Withdraws");
                });

            modelBuilder.Entity("FinancialControl.Domain.Entities.CashierAccount", b =>
                {
                    b.HasOne("FinancialControl.Domain.Entities.Cashier", "Cashier")
                        .WithMany()
                        .HasForeignKey("CashierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cashier");
                });

            modelBuilder.Entity("FinancialControl.Domain.Entities.Category", b =>
                {
                    b.HasOne("FinancialControl.Domain.Entities.Category", "SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryId");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("FinancialControl.Domain.Entities.Transaction", b =>
                {
                    b.HasOne("FinancialControl.Domain.Entities.CashierAccount", "CashierAccount")
                        .WithMany()
                        .HasForeignKey("CashierAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinancialControl.Domain.Entities.Category", "Category")
                        .WithMany("Transactions")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CashierAccount");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FinancialControl.Domain.Entities.Category", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
