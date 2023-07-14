using CodeNotes.Domain.Aggregates;
using CodeNotes.Domain.Repository;
using MediatR;

namespace CodeNotes.Application.Notifications.UserCreated;

internal class UserCreatedNotificationHandler : INotificationHandler<UserCreatedNotification>
{
    private readonly INotesRepository<Note> _notesRepository;

    public UserCreatedNotificationHandler(INotesRepository<Note> notesRepository)
    {
        _notesRepository = notesRepository;
    }

    public async Task Handle(UserCreatedNotification notification, CancellationToken cancellationToken)
    {
        var note = new Note
        {
            UserId = notification.UserId,
        };

        await Task.CompletedTask;

        // await _notesRepository.Create(note);
    }
}
