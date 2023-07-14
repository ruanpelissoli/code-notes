using CodeNotes.Application.Messaging;

namespace CodeNotes.Application.UseCases.Users.LoginUser;
public record LoginCommand(string Email, string Password)
    : ICommand<LoginCommandResponse>;
