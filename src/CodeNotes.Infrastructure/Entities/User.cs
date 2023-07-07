using CodeNotes.Domain;

namespace CodeNotes.Infrastructure.Entities;

public class User : IAggregateRoot
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Bio { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}
