using Postgrest.Attributes;
using Postgrest.Models;

namespace CodeNotes.Infrastructure.Entities;

[Table("chapter")]
internal class ChapterEntity : BaseModel
{
    [PrimaryKey("id", false)]
    public long Id { get; set; }

    [Column("title")]
    public string Title { get; set; } = null!;

    [Column("is_active")]
    public bool IsActive { get; set; }

    [Column("created_at")]
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
}
