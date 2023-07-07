using Postgrest.Models;

namespace CodeNotes.Infrastructure.Entities;

public class Chapter : BaseModel
{
    public long Id { get; set; }
    public long NoteId { get; set; }
    public string Title { get; set; }
    public ICollection<Topic> Topics { get; set; }
    public bool IsActive { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}
