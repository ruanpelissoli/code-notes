using Postgrest.Attributes;
using Postgrest.Models;

namespace CodeNotes.Infrastructure.Entities;

[Table("comment")]
internal class CommentEntity : BaseModel
{
    [PrimaryKey("id", false)]
    public long Id { get; set; }

    [Column("user_id")]
    public long UserId { get; set; }

    [Column("user_id")]
    public long ReplyingToUserId { get; set; }

    [Column("user_id")]
    public long ArticleId { get; set; }

    [Column("user_id")]
    public string Text { get; set; } = null!;

    [Column("is_active")]
    public bool IsActive { get; set; } = true;

    [Column("created_at")]
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
}
