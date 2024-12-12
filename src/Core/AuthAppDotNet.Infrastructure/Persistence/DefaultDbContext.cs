﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthAppDotNet.Infrastructure.Persistence;

public sealed class DefaultDbContext : IdentityDbContext
{
    public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options) { }

    #region Authentication
    //public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    //public DbSet<Role> Roles { get; set; }
    #endregion

    // This is for entity (configuration) reading 
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    //    base.OnModelCreating(modelBuilder);
    //}
}
