using Carter;
using CodeNotes.Application.UseCases.Notes.CreateNote;
using MediatR;

namespace CodeNotes.API.Modules;

public class NotesModule : CarterModule
{
    public NotesModule() : base("notes")
    {
        RequireAuthorization();
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/chapters", async (
            CreateNoteCommand command,
            ISender _sender) =>
        {

            var post = await _sender.Send(command);

            if (post is null)
                return Results.NoContent();

            return Results.Ok();
        })
        .WithName("PostNote")
        .WithOpenApi();
    }
}
