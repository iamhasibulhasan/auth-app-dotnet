using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AuthAppDotNet.Infrastructure.Persistence;

public sealed class DefaultDbContext : DbContext
{
    public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options) { }



    // This is for entity (configuration) reading 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
