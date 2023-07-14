using MediatR;

namespace CodeNotes.Application.Notifications.UserCreated;

internal record UserCreatedNotification(Guid UserId) : INotification;
