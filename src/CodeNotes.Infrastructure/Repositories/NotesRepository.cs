using CodeNotes.Domain.Repository;
using CodeNotes.Infrastructure.Entities;

namespace CodeNotes.Infrastructure.Repositories;
internal class NotesRepository : IBaseRepository<Note>
{
    public Task Create(Note model)
    {
        throw new NotImplementedException();
    }

    public Task<Note?> GetAsync(long id)
    {
        throw new NotImplementedException();
    }
}
