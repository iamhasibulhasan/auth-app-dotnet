using AuthAppDotNet.Application.RepositoryInterfaces.Common;
using AuthAppDotNet.Domain.Users;

namespace AuthAppDotNet.Application.RepositoryInterfaces.Authentication
{
    public interface IApplicationUserRepository : IGenericRepository<ApplicationUser>
    {
    }
}
