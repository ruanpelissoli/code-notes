using CodeNotes.Application.Messaging;
using CodeNotes.Domain.Aggregates;
using CodeNotes.Domain.Application;
using CodeNotes.Domain.Repository;

namespace CodeNotes.Application.UseCases.Users.LoginUser;
internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, LoginCommandResponse>
{
    private readonly IUserRepository<User> _userRepository;

    public LoginCommandHandler(IUserRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<LoginCommandResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var token = await _userRepository.Login(request.Email, request.Password);

        if (string.IsNullOrWhiteSpace(token))
            return Result.Failure<LoginCommandResponse>(new Error(
                "Error.Login",
                "Invalid Credentials"));

        return Result.Success(new LoginCommandResponse(token));
    }
}
