using AuthAppDotNet.Application.Common.Utilities;
using MediatR;

namespace AuthAppDotNet.Application.Abstraction.MediatR;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
