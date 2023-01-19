﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Security.Jwt.Core.Model;
using NetDevPack.Security.Jwt.Store.EntityFrameworkCore;

namespace FinancialControl.Infra.CrossCutting.Security.Data
{
    public class SecurityDbContext : IdentityDbContext, ISecurityKeyContext
    {
        public SecurityDbContext(DbContextOptions<SecurityDbContext> options) : base(options) { }
        public DbSet<KeyMaterial> SecurityKeys { get; set; }
    }
}
