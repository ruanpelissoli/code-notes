using Postgrest.Models;

namespace CodeNotes.Infrastructure.Entities;
public class Comment : BaseModel
{
    public long Id { get; set; }
    public long ArticleId { get; set; }
    public long UserId { get; set; }
    public long ReplyingToUserId { get; set; }
    public string Text { get; set; }
    public bool IsActive { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}
