using FluentValidation;

namespace CodeNotes.Application.UseCases.Users.CreateUser;

internal sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(r => r.Email).NotEmpty();
        RuleFor(r => r.Username).NotEmpty();
        RuleFor(r => r.Password).NotEmpty();
    }
}
