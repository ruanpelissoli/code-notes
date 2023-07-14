using Postgrest.Attributes;
using Postgrest.Models;

namespace CodeNotes.Infrastructure.Entities;

[Table("note")]
public class NoteEntity : BaseModel
{
    [PrimaryKey("id", false)]
    public long Id { get; set; }

    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("chapter_id")]
    public long ChapterId { get; set; }

    [Column("topic_id")]
    public long TopicId { get; set; }

    [Column("title")]
    public string Title { get; set; } = null!;

    [Column("rich_text")]
    public string RichText { get; set; } = null!;

    [Column("is_active")]
    public bool IsActive { get; set; } = true;

    [Column("is_draft")]
    public bool IsDraft { get; set; } = true;

    [Column("views")]
    public int Views { get; set; }

    [Column("created_at")]
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
}
