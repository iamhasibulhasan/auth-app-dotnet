using AuthAppDotNet.Application.Common.Utilities;
using AuthAppDotNet.Application.Features.Authentication.ApplicationUser;
using AuthAppDotNet.Application.Features.Authentication.ApplicationUser.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthAppDotNet.Api.Areas.Authentication;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("signup")]
    public async Task<IActionResult> SignUp([FromBody] ApplicationUserCreateDto model, CancellationToken cancellationToken = default)
    {
        Result result;

        var validationResult = new ApplicationUserCreateDtoValidator().Validate(model);
        if (validationResult.IsValid)
        {
            var command = new ApplicationUserCreateCommand(model);
            result = await _mediator.Send(command, cancellationToken);
        }
        else
        {
            result = Utility.GetValidationFailedMsg(FluentValidationHelper.GetErrorMessage(validationResult.Errors));
        }
        return StatusCode(result.StatusCode, result);
    }

    [HttpPost("signin")]
    public async Task<IActionResult> SignIn([FromBody] SingInDto model, CancellationToken cancellationToken = default)
    {
        Result result;

        var validationResult = new SingInDtoValidator().Validate(model);
        if (validationResult.IsValid)
        {
            var command = new SingInCommand(model);
            result = await _mediator.Send(command, cancellationToken);
        }
        else
        {
            result = Utility.GetValidationFailedMsg(FluentValidationHelper.GetErrorMessage(validationResult.Errors));
        }
        return StatusCode(result.StatusCode, result);
    }
}
