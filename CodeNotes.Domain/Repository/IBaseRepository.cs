namespace CodeNotes.Domain.Repository;
public interface IBaseRepository<T> where T : IAggregateRoot
{
    Task Create(T model);
    Task<T?> GetAsync(long id);
}
