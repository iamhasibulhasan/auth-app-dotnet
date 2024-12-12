using AuthAppDotNet.Application.Abstraction.MediatR;
using AuthAppDotNet.Application.Common.Utilities;
using AuthAppDotNet.Application.Features.Authentication.ApplicationUser.Dto;
using AuthAppDotNet.Application.ServiceInterfaces.Authentication;

namespace AuthAppDotNet.Application.Features.Authentication.ApplicationUser
{
    public sealed record ApplicationUserCreateCommand(ApplicationUserCreateDto model) : ICommand;
    public sealed class ApplicationUserCreateCommandHandler : ICommandHandler<ApplicationUserCreateCommand>
    {
        private readonly IApplicationUserService _applicationUserService;

        public ApplicationUserCreateCommandHandler(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
        }
        public async Task<Result> Handle(ApplicationUserCreateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
