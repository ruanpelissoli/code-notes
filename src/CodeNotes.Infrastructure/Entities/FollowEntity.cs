using CodeNotes.Domain;
using Postgrest.Attributes;
using Postgrest.Models;

namespace CodeNotes.Infrastructure.Entities;

[Table("article")]
internal class FollowEntity : BaseModel, IAggregateRoot
{
    [PrimaryKey("id", false)]
    public long Id { get; set; }

    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("following")]
    public string? Following { get; set; }
}
