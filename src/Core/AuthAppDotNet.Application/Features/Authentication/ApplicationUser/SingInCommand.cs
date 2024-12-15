using AuthAppDotNet.Application.Abstraction.MediatR;
using AuthAppDotNet.Application.Common.Utilities;
using AuthAppDotNet.Application.Features.Authentication.ApplicationUser.Dto;
using AuthAppDotNet.Application.ServiceInterfaces.Authentication;

namespace AuthAppDotNet.Application.Features.Authentication.ApplicationUser
{
    public sealed record SingInCommand(SingInDto model) : ICommand;
    public sealed class SingInCommandHandler : ICommandHandler<SingInCommand>
    {
        private readonly IApplicationUserService _applicationUserService;

        public SingInCommandHandler(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
        }
        public async Task<Result> Handle(SingInCommand request, CancellationToken cancellationToken)
        {
            return await _applicationUserService.SignIn(request.model, cancellationToken);
        }
    }
}
