using CodeNotes.Application.Messaging;
using CodeNotes.Domain.Aggregates;
using CodeNotes.Domain.Application;
using CodeNotes.Domain.Repository;

namespace CodeNotes.Application.UseCases.Notes.CreateNote;
internal class CreateNoteCommandHandler : ICommandHandler<CreateNoteCommand, CreateNoteResponse>
{
    private readonly INotesRepository<Note> _notesRepository;

    public CreateNoteCommandHandler(INotesRepository<Note> notesRepository)
    {
        _notesRepository = notesRepository;
    }

    public async Task<Result<CreateNoteResponse>> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        var note = new Note
        {
            UserId = request.UserId,
            ChapterId = request.ChapterId,
            ChapterTitle = request.ChapterTitle,
            TopicId = request.TopicId,
            TopicTitle = request.TopicTitle,
            Title = request.Title,
            RichText = request.RichText
        };

        await _notesRepository.Create(note);

        return Result.Success(new CreateNoteResponse());
    }
}
