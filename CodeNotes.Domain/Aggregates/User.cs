namespace CodeNotes.Domain.Aggregates;

public class User : IAggregateRoot
{
    public long Id { get; set; }

    public Guid UserId { get; set; }

    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string? Bio { get; set; }
}
