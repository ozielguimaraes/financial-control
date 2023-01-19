﻿using FinancialControl.Infra.CrossCutting.Security.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FinancialControl.Infra.CrossCutting.Security.Data
{
    public static class MigrationHelper
    {
        /// <summary>
        /// Generate migrations before running this method, you can use command bellow:
        /// Nuget package manager: Add-Migration DbInit -context SecurityDbContext
        /// Dotnet CLI: dotnet ef migrations add DbInit -c SecurityDbContext
        /// </summary>
        public static async Task EnsureSeedData(WebApplication app)
        {
            var services = app.Services.CreateScope().ServiceProvider;
            await EnsureSeedData(services);
        }

        public static async Task EnsureSeedData(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

            var ssoContext = scope.ServiceProvider.GetRequiredService<SecurityDbContext>();

            await DbHealthChecker.TestConnection(ssoContext);

            if (env.IsDevelopment() || env.IsEnvironment("Docker"))
                await ssoContext.Database.EnsureCreatedAsync();
        }
    }
}
