using CodeNotes.Domain.Aggregates;
using CodeNotes.Domain.Repository;
using CodeNotes.Infrastructure.Entities;
using Postgrest;
using static Postgrest.QueryOptions;

namespace CodeNotes.Infrastructure.Repositories;
internal class UsersRepository : IUserRepository<User>
{
    private readonly Supabase.Client _supabaseClient;

    public UsersRepository(Supabase.Client supabaseClient)
    {
        _supabaseClient = supabaseClient;
    }

    public async Task<(Guid, string?)> CreateUser(User user, string password)
    {
        var session = await _supabaseClient.Auth.SignUp(user.Email, password);

        if (session?.User == null)
            return (Guid.Empty, string.Empty);

        var userId = Guid.Parse(session.User.Id!);

        var userEntity = new UserInfoEntity
        {
            UserId = userId,
            Email = user.Email,
            Username = user.Username,
            Bio = user.Bio,
        };

        await _supabaseClient.From<UserInfoEntity>()
            .Insert(userEntity, new QueryOptions { Returning = ReturnType.Minimal });

        return (userId, session.AccessToken);
    }

    public async Task<string?> Login(string email, string password)
    {
        try
        {
            var session = await _supabaseClient.Auth.SignIn(email, password);

            return session?.AccessToken;
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    public async Task Logout()
    {
        await _supabaseClient.Auth.SignOut();
    }
}
