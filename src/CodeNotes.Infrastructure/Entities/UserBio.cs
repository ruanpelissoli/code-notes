using Postgrest.Attributes;
using Postgrest.Models;

namespace CodeNotes.Infrastructure.Entities;

[Table("user_bio")]
public class UserBio : BaseModel
{
    [PrimaryKey("id", false)]
    public long Id { get; set; }

    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("username")]
    public string Username { get; set; } = null!;

    [Column("bio")]
    public string? Bio { get; set; }

    [Column("created_at")]
    public DateTimeOffset CreatedAt { get; set; }
}
