namespace CodeNotes.Domain.Repository;
public interface IUserRepository<T> where T : IAggregateRoot
{
    Task<string?> CreateUser(T user);
    Task<string?> Login(string email, string password);
    Task Logout();
}
