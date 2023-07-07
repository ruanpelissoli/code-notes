using Carter;
using CodeNotes.API.Requests;
using CodeNotes.Domain.Repository;
using CodeNotes.Infrastructure.Entities;
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
            [FromBody] CreateUserRequest request,
            [FromServices] IUserRepository<User> userRepository) =>
        {
            var user = new User
            {
                Email = request.Email,
                Username = request.Username,
                Password = request.Password,
                Bio = request.Bio,
            };

            var token = await userRepository.CreateUser(user);

            if (string.IsNullOrEmpty(token))
                return Results.BadRequest();

            return Results.Ok(token);
        })
        .WithName("CreateUser")
        .WithOpenApi();

        app.MapPost("/login", async (
            [FromBody] LoginRequest request,
            [FromServices] IUserRepository<User> userRepository) =>
        {
            var token = await userRepository.Login(request.Email, request.Password);

            if (string.IsNullOrEmpty(token))
                return Results.BadRequest();

            return Results.Ok(token);
        })
        .WithName("Login")
        .WithOpenApi();
    }
}
