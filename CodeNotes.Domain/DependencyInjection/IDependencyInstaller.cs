using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeNotes.Domain.DependencyInjection;

public interface IDependencyInstaller
{
    void Install(IServiceCollection services, IConfiguration configuration);
}
