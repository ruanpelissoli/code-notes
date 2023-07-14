using CodeNotes.Domain.Aggregates;
using CodeNotes.Domain.Repository;
using CodeNotes.Infrastructure.Entities;
using Postgrest;
using static Postgrest.QueryOptions;

namespace CodeNotes.Infrastructure.Repositories;
internal class NotesRepository : INotesRepository<Note>
{
    private readonly Supabase.Client _supabaseClient;

    public NotesRepository(Supabase.Client supabaseClient)
    {
        _supabaseClient = supabaseClient;
    }

    public async Task Create(Note noteAggregate)
    {
        long chapterId;

        if (!noteAggregate.ChapterId.HasValue)
        {
            var chapter = await CreateChapter(new ChapterEntity
            {
                Title = noteAggregate.ChapterTitle!,
            });

            chapterId = chapter.Id;
        }
        else
            chapterId = noteAggregate.ChapterId.Value;

        long topicId;

        if (!noteAggregate.TopicId.HasValue)
        {
            var topic = await CreateTopic(new TopicEntity
            {
                ChapterId = chapterId,
                Title = noteAggregate.TopicTitle!,
            });

            topicId = topic.Id;
        }
        else
            topicId = noteAggregate.TopicId.Value;

        var note = new NoteEntity
        {
            UserId = noteAggregate.UserId,
            ChapterId = chapterId,
            TopicId = topicId,
            Title = noteAggregate.Title,
            RichText = noteAggregate.RichText,
        };

        await _supabaseClient.From<NoteEntity>()
           .Insert(note, new QueryOptions { Returning = ReturnType.Minimal });
    }

    private async Task<ChapterEntity> CreateChapter(ChapterEntity chapter)
    {
        var response = await _supabaseClient.From<ChapterEntity>()
           .Insert(chapter, new QueryOptions { Returning = ReturnType.Representation });

        return response.Models.First();
    }

    private async Task<TopicEntity> CreateTopic(TopicEntity topic)
    {
        var response = await _supabaseClient.From<TopicEntity>()
          .Insert(topic, new QueryOptions { Returning = ReturnType.Representation });

        return response.Models.First();
    }
}
