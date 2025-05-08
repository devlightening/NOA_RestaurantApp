using FluentValidation;

namespace Application.Features.Rastraunts.Commands.Delete;

public class DeleteRastrauntCommandValidator : AbstractValidator<DeleteRastrauntCommand>
{
    public DeleteRastrauntCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}