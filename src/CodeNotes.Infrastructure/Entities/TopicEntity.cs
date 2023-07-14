using Postgrest.Attributes;
using Postgrest.Models;

namespace CodeNotes.Infrastructure.Entities;

[Table("topic")]
internal class TopicEntity : BaseModel
{
    [PrimaryKey("id", false)]
    public long Id { get; set; }

    [Column("chapter_id")]
    public long ChapterId { get; set; }

    [Column("title")]
    public string Title { get; set; } = null!;

    [Column("is_active")]
    public bool IsActive { get; set; } = true;

    [Column("created_at")]
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
}
