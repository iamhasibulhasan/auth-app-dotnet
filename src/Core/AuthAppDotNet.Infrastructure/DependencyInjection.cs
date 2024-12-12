using AuthAppDotNet.Domain.Users;
using AuthAppDotNet.Infrastructure.Persistence;
using AuthAppDotNet.Infrastructure.RepositoryImplementations.Authentication;
using AuthAppDotNet.Infrastructure.ServiceImplementations.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using System.Reflection;

namespace AuthAppDotNet.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DefaultDbContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("DbConnection"), b => b.MigrationsAssembly(typeof(DefaultDbContext).Assembly.FullName)));

        // services from identity core
        services.AddIdentityApiEndpoints<ApplicationUser>()
            .AddEntityFrameworkStores<DefaultDbContext>();
        Dependency(services);
        return services;
    }
    public static void Dependency(this IServiceCollection services)
    {
        var assembliesToScan = new[]
        {
            Assembly.GetExecutingAssembly(),
            Assembly.GetAssembly(typeof(ApplicationUserService)),
            Assembly.GetAssembly(typeof(ApplicationUserRepository))
        };
        services.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
            .Where(c => c.Name.EndsWith("Service") || c.Name.EndsWith("Repository"))
            .AsPublicImplementedInterfaces();
    }
}

