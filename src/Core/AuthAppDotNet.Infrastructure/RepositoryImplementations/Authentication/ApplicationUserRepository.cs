using AuthAppDotNet.Application.RepositoryInterfaces.Authentication;
using AuthAppDotNet.Domain.Users;
using AuthAppDotNet.Infrastructure.Persistence;
using AuthAppDotNet.Infrastructure.RepositoryImplementations.Common;

namespace AuthAppDotNet.Infrastructure.RepositoryImplementations.Authentication;

public sealed class ApplicationUserRepository : GenericRepository<ApplicationUser>, IApplicationUserRepository
{
    private readonly DefaultDbContext _defaultDbContext;

    public ApplicationUserRepository(DefaultDbContext defaultDbContext) : base(defaultDbContext)
    {
        _defaultDbContext = defaultDbContext;
    }
}
