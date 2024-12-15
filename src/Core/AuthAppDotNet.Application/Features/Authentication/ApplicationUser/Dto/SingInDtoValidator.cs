using FluentValidation;

namespace AuthAppDotNet.Application.Features.Authentication.ApplicationUser.Dto;

public sealed class SingInDtoValidator : AbstractValidator<SingInDto>
{
    public SingInDtoValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("{PropertyName} is required.");
        RuleFor(x => x.Password).NotEmpty().WithMessage("{PropertyName} is required.");
    }
}
