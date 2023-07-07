using Carter;
using CodeNotes.Domain.Repository;
using CodeNotes.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CodeNotes.API.Modules;

public class NotesModule : CarterModule
{
    public NotesModule() : base("notes")
    {
        RequireAuthorization();
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/chapters/{id}", async (
            long id,
            [FromServices] IBaseRepository<Note> notesRepository) =>
        {

            var post = await notesRepository.GetAsync(id);

            if (post is null)
                return Results.NoContent();

            return Results.Ok();
        })
        .WithName("GetChapters")
        .WithOpenApi();

        app.MapPost("/chapters", async (
            long id,
            [FromServices] IBaseRepository<Note> notesRepository) =>
        {

            var post = await notesRepository.GetAsync(id);

            if (post is null)
                return Results.NoContent();

            return Results.Ok();
        })
        .WithName("PostChapter")
        .WithOpenApi();
    }
}
