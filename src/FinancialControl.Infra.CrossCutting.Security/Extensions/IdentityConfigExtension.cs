using FinancialControl.Infra.CrossCutting.Security.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Identity.Jwt;
using NetDevPack.Security.PasswordHasher.Core;
using static FinancialControl.Infra.CrossCutting.Security.ProviderConfiguration;

namespace FinancialControl.Infra.CrossCutting.Security.Extensions
{
    public static class IdentityConfigExtension
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureProviderForContext<SecurityDbContext>(DetectDatabase(configuration));

            services.AddMemoryCache()
                    .AddDataProtection();

            services.AddJwtConfiguration(configuration, "AppSettings")
                    .AddNetDevPackIdentity<IdentityUser>()
                    .PersistKeysToDatabaseStore<SecurityDbContext>();

            services.AddIdentity<IdentityUser, IdentityRole>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequireUppercase = false;
                o.Password.RequiredUniqueChars = 0;
                o.Password.RequiredLength = 6;
            })
                .AddEntityFrameworkStores<SecurityDbContext>()
                .AddDefaultTokenProviders();

            services.UpgradePasswordSecurity()
                .WithStrenghten(PasswordHasherStrenght.Moderate)
                .UseArgon2<IdentityUser>();

            return services;
        }
    }
}
