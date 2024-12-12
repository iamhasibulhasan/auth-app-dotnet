using AuthAppDotNet.Domain.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AuthAppDotNet.Infrastructure.Persistence;

public sealed class DefaultDbContext : IdentityDbContext<ApplicationUser, Role, int>
{
    public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options) { }

    #region Authentication
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Role> Roles { get; set; }
    #endregion

    //This is for entity(configuration) reading
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
