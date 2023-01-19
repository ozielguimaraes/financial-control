using FinancialControl.Domain.Entities;
using FinancialControl.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FinancialControl.Infra.Data.Context
{
    public class MainContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public MainContext(DbContextOptions<MainContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Withdraw> Withdraws { get; set; }
        public DbSet<Cashier> Cashiers { get; set; }
        public DbSet<CashierAccount> CashierAccounts { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
             modelBuilder.ApplyConfiguration(new TransactionMap());
             modelBuilder.ApplyConfiguration(new WithdrawMap());
             modelBuilder.ApplyConfiguration(new CashierMap());
             modelBuilder.ApplyConfiguration(new CashierAccountMap());
             
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 3,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
                }
            );
            optionsBuilder.LogTo(Console.WriteLine);
        }
    }
}
