using AuthAppDotNet.Application.Common.Utilities;
using AuthAppDotNet.Application.Features.Authentication.ApplicationUser.Dto;
using AuthAppDotNet.Application.RepositoryInterfaces.Authentication;
using AuthAppDotNet.Application.ServiceInterfaces.Authentication;
using AuthAppDotNet.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Utility = AuthAppDotNet.Application.Common.Utilities.Utility;

namespace AuthAppDotNet.Infrastructure.ServiceImplementations.Authentication
{
    public sealed class ApplicationUserService : IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUserRepository _applicationUserRepository;

        public JwtOptions _options;

        public ApplicationUserService(IApplicationUserRepository applicationUserRepository,
            UserManager<ApplicationUser> userManager,
            IOptions<JwtOptions> options
            )
        {
            _applicationUserRepository = applicationUserRepository;
            _userManager = userManager;
            _options = options.Value;
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

        public async Task<Result> SignIn(SingInDto model, CancellationToken cancellationToken, bool saveChanges = true)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user is not null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var token = GenerateToken(user);
                return Utility.GetSuccessMsg("", token);
            }
            else
            {
                return Utility.GetErrorMsg(CommonMessages.Unauthorized);
            }
        }

        private string GenerateToken(ApplicationUser applicationUser)
        {
            var claims = new Claim[] {
            new (JwtRegisteredClaimNames.Sub, applicationUser.Id.ToString()),
            new (JwtRegisteredClaimNames.Email, applicationUser.Email),
            new ("UserName",applicationUser.UserName)
            };

            var signingCreadentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Secret)),
               SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _options.Issuer,
                _options.Audience,
                claims,
                null,
                DateTime.UtcNow.AddHours(1),
                null);
            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return $"Bearer {tokenValue}";
        }
    }
}
