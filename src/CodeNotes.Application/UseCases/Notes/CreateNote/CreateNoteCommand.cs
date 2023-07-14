using CodeNotes.Application.Messaging;

namespace CodeNotes.Application.UseCases.Notes.CreateNote;
public record CreateNoteCommand(
    Guid UserId,
    long? ChapterId,
    string ChapterTitle,
    long? TopicId,
    string TopicTitle,
    string Title,
    string RichText
    ) : ICommand<CreateNoteResponse>;
