using CodeNotes.Application.Messaging;

namespace CodeNotes.Application.UseCases.Users.CreateUser;
public record CreateUserCommand(string Email, string Password, string Username, string? Bio)
    : ICommand<CreateUserResponse>;
