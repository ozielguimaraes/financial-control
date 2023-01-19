using FinancialControl.Domain.Business.Implementations;
using FinancialControl.Domain.Business.Interfaces;
using FinancialControl.Domain.Interfaces;
using FinancialControl.Domain.Interfaces.Repositories;
using FinancialControl.Domain.Interfaces.Services;
using FinancialControl.Domain.Services;
using FinancialControl.Infra.CrossCutting.Security;
using FinancialControl.Infra.CrossCutting.Security.Shared;
using FinancialControl.Infra.Data.Context;
using FinancialControl.Infra.Data.Repositories;
using FinancialControl.Infra.Data.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialControl.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);

            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUser, AspNetUser>();

            // Domain.Business
            services.AddScoped<IAuthBusiness, AuthBusiness>();
            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<ITransactionBusiness, TransactionBusiness>();
            services.AddScoped<IWithdrawBusiness, WithdrawBusiness>();
            services.AddScoped<ICategoryBusiness, CategoryBusiness>();
            services.AddScoped<ICashierBusiness, CashierBusiness>();
            services.AddScoped<ICashierAccountBusiness, CashierAccountBusiness>();

            // Domain
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IWithdrawService, WithdrawService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICashierService, CashierService>();
            services.AddScoped<ICashierAccountService, CashierAccountService>();

            // Infra - Data
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IWithdrawRepository, WithdrawRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICashierRepository, CashierRepository>();
            services.AddScoped<ICashierAccountRepository, CashierAccountRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<MainContext>();
        }
    }
}
