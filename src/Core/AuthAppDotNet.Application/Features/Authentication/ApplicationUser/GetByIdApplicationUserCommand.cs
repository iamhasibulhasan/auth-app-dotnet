using AuthAppDotNet.Application.Abstraction.MediatR;
using AuthAppDotNet.Application.Common.Utilities;
using AuthAppDotNet.Application.ServiceInterfaces.Authentication;

namespace AuthAppDotNet.Application.Features.Authentication.ApplicationUser
{
    public sealed record GetByIdApplicationUserCommand(int id) : IQuery<Result>;
    public sealed class GetByIdApplicationUserCommandHandler : IQueryHandler<GetByIdApplicationUserCommand, Result>
    {
        private readonly IApplicationUserService _applicationUserService;

        public GetByIdApplicationUserCommandHandler(IApplicationUserService applicationUserService)
        {
            _applicationUserService = applicationUserService;
        }
        public async Task<Result> Handle(GetByIdApplicationUserCommand request, CancellationToken cancellationToken)
        {
            return await _applicationUserService.GetById(request.id, cancellationToken);
        }
    }
}
