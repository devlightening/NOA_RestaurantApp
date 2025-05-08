using FluentValidation;

namespace Application.Features.Rastraunts.Commands.Update;

public class UpdateRastrauntCommandValidator : AbstractValidator<UpdateRastrauntCommand>
{
    public UpdateRastrauntCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
        RuleFor(c => c.PhoneNumber).NotEmpty();
    }
}