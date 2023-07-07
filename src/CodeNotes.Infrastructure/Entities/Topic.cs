using Postgrest.Models;

namespace CodeNotes.Infrastructure.Entities;

public class Topic : BaseModel
{
    public long Id { get; set; }
    public long ChapterId { get; set; }
    public string Title { get; set; }
    public ICollection<Article> Articles { get; set; }
    public bool IsActive { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}
