namespace CodeNotes.Domain.Repository;
public interface INotesRepository<T> where T : IAggregateRoot
{
    Task Create(T model);
    //Task<Chapter> CreateChapter(Chapter chapter);
    //Task<Topic> CreateTopic(Topic topic);
}
