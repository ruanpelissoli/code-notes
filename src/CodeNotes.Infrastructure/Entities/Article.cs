using Postgrest.Models;

namespace CodeNotes.Infrastructure.Entities;

public class Article : BaseModel
{
    public long Id { get; set; }
    public long TopicId { get; set; }
    public string Title { get; set; }
    public string RichText { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public bool IsActive { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}
