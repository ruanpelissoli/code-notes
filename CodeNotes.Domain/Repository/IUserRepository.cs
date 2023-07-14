namespace CodeNotes.Domain.Repository;
public interface IUserRepository<T> where T : IAggregateRoot
{
    Task<(Guid, string?)> CreateUser(T user, string password);
    Task<string?> Login(string email, string password);
    Task Logout();
}
