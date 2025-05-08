using FluentValidation;

namespace Application.Features.Rastraunts.Commands.Create;

public class CreateRastrauntCommandValidator : AbstractValidator<CreateRastrauntCommand>
{
    public CreateRastrauntCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
        RuleFor(c => c.PhoneNumber).NotEmpty();
    }
}