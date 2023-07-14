using CodeNotes.Application.Messaging;
using CodeNotes.Application.Notifications.UserCreated;
using CodeNotes.Domain.Aggregates;
using CodeNotes.Domain.Application;
using CodeNotes.Domain.Repository;
using MediatR;

namespace CodeNotes.Application.UseCases.Users.CreateUser;
internal sealed class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, CreateUserResponse>
{
    private readonly IUserRepository<User> _userRepository;
    private readonly IPublisher _publisher;

    public CreateUserCommandHandler(IUserRepository<User> userRepository, IPublisher publisher)
    {
        _userRepository = userRepository;
        _publisher = publisher;
    }

    public async Task<Result<CreateUserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Email = request.Email,
            Username = request.Username,
            Bio = request.Bio,
        };

        var (userId, token) = await _userRepository.CreateUser(user, request.Password);

        if (userId != Guid.Empty)
            await _publisher.Publish(new UserCreatedNotification(userId));

        return Result.Success(new CreateUserResponse(token));
    }
}
