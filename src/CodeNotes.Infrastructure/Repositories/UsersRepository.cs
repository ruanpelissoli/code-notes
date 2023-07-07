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

    public async Task<string?> CreateUser(User user)
    {
        var session = await _supabaseClient.Auth.SignUp(user.Email, user.Password);

        if (session?.User == null)
            return string.Empty;

        var userBio = new UserBio
        {
            UserId = Guid.Parse(session.User.Id!),
            Username = user.Username,
            Bio = user.Bio,
            CreatedAt = DateTimeOffset.UtcNow
        };

        await _supabaseClient.From<UserBio>()
            .Insert(userBio, new QueryOptions { Returning = ReturnType.Minimal });

        return session.AccessToken;
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
