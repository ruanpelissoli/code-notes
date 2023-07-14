using Postgrest.Attributes;

namespace CodeNotes.Infrastructure.Entities;

[Table("like")]
internal class LikeEntity
{
    [PrimaryKey("id", false)]
    public long Id { get; set; }

    [Column("article_id")]
    public long ArticleId { get; set; }

    [Column("likes")]
    public string? Likes { get; set; }
}
