using Carter;
using CodeNotes.Application.UseCases.Users.CreateUser;
using CodeNotes.Application.UseCases.Users.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeNotes.API.Modules;

public class UsersModule : CarterModule
{
    public UsersModule() : base("users")
    {

    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/create", async (
            [FromBody] CreateUserCommand command,
            ISender sender) =>
        {
            var response = await sender.Send(command);

            if (response.IsFailure)
                return Results.BadRequest(response);

            return Results.Ok(response.Value);
        })
        .WithName("CreateUser")
        .WithOpenApi();

        app.MapPost("/login", async (
            [FromBody] LoginCommand command,
            ISender sender) =>
        {
            var response = await sender.Send(command);

            if (response.IsFailure)
                return Results.BadRequest(response);

            return Results.Ok(response.Value);
        })
        .WithName("Login")
        .WithOpenApi();
    }
}
