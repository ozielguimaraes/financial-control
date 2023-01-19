using System;
using Microsoft.AspNetCore.Builder;
using FinancialControl.Infra.CrossCutting.Security.Builders;
using FinancialControl.Infra.CrossCutting.Security.Policies;

namespace FinancialControl.Infra.CrossCutting.Security.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseSecurityHeadersMiddleware(this IApplicationBuilder app, SecurityHeadersBuilder builder)
        {
            SecurityHeadersPolicy policy = builder.Build();
            return app.UseMiddleware<SecurityHeadersMiddleware>(policy);
        }
    }
}
