using CodeNotes.Domain.Aggregates;
using CodeNotes.Domain.DependencyInjection;
using CodeNotes.Domain.Repository;
using CodeNotes.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeNotes.Infrastructure;
public class DependencyInstaller : IDependencyInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(_ =>
            new Supabase.Client(
                configuration["SupabaseUrl"]!,
                configuration["SupabaseKey"]!,
                new Supabase.SupabaseOptions
                {
                    AutoRefreshToken = true,
                    AutoConnectRealtime = true
                }));

        services.AddScoped<INotesRepository<Note>, NotesRepository>();
        services.AddScoped<IUserRepository<Domain.Aggregates.User>, UsersRepository>();
    }
}
