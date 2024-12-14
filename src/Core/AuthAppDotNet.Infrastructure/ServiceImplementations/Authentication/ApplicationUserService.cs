using AuthAppDotNet.Application.Common.Utilities;
using AuthAppDotNet.Application.Features.Authentication.ApplicationUser.Dto;
using AuthAppDotNet.Application.RepositoryInterfaces.Authentication;
using AuthAppDotNet.Application.ServiceInterfaces.Authentication;
using AuthAppDotNet.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace AuthAppDotNet.Infrastructure.ServiceImplementations.Authentication
{
    public sealed class ApplicationUserService : IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUserRepository _applicationUserRepository;

        public ApplicationUserService(IApplicationUserRepository applicationUserRepository, UserManager<ApplicationUser> userManager)
        {
            _applicationUserRepository = applicationUserRepository;
            _userManager = userManager;
        }

        public async Task<Result> Create(ApplicationUserCreateDto model, CancellationToken cancellationToken, bool saveChanges = true)
        {
            ApplicationUser user = new();
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.Name = model.Name;
            user.IsAdmin = model.IsAdmin;
            user.Address = model.Address;
            user.PhoneNumber = model.PhoneNumber;
            await _userManager.CreateAsync(user, model.Password); // for identity usermanager

            var userData = new
            {
                user.Id,
                user.UserName,
                user.Name,
                user.Email,
                user.PhoneNumber,
            };
            return Utility.GetSuccessMsg(CommonMessages.SavedSuccessfully, userData);
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
