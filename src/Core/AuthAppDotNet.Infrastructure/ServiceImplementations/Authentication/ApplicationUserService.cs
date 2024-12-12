using AuthAppDotNet.Application.Common.Utilities;
using AuthAppDotNet.Application.Features.Authentication.ApplicationUser.Dto;
using AuthAppDotNet.Application.RepositoryInterfaces.Authentication;
using AuthAppDotNet.Application.ServiceInterfaces.Authentication;

namespace AuthAppDotNet.Infrastructure.ServiceImplementations.Authentication
{
    public sealed class ApplicationUserService : IApplicationUserService
    {
        private readonly IApplicationUserRepository _repository;

        public ApplicationUserService(IApplicationUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Create(ApplicationUserCreateDto model, CancellationToken cancellationToken, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> GetAll(int page, int size, int statusId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> GetById(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> ModifyStatus(int id, int statusId, CancellationToken cancellationToken, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> Update(ApplicationUserCreateDto model, CancellationToken cancellationToken, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
