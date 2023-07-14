namespace CodeNotes.Domain.Aggregates;
public class Note : IAggregateRoot
{
    public long Id { get; set; }
    public Guid UserId { get; set; }
    public long? ChapterId { get; set; }
    public string? ChapterTitle { get; set; }
    public long? TopicId { get; set; }
    public string? TopicTitle { get; set; }
    public string Title { get; set; } = null!;
    public string RichText { get; set; } = null!;
}
