using CodeNotes.Domain;
using Postgrest.Models;

namespace CodeNotes.Infrastructure.Entities;

public class Note : BaseModel, IAggregateRoot
{
    public long Id { get; set; }
    public Guid UserId { get; set; }
    public ICollection<Chapter> Chapters { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}
