using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CodeNotes.Domain.DependencyInjection;

public static class DependencyInstallerExtensions
{
    public static IServiceCollection InstallServices(
        this IServiceCollection services,
        IConfiguration configuration,
        params Assembly[] assemblies)
    {
        IEnumerable<IDependencyInstaller> serviceInstallers = assemblies
            .SelectMany(_ => _.DefinedTypes)
            .Where(IsAssignableToType<IDependencyInstaller>)
            .Select(Activator.CreateInstance)
            .Cast<IDependencyInstaller>();

        foreach (IDependencyInstaller serviceInstaller in serviceInstallers)
        {
            serviceInstaller.Install(services, configuration);
        }

        return services;

        static bool IsAssignableToType<T>(TypeInfo typeInfo) =>
            typeof(T).IsAssignableFrom(typeInfo) &&
            !typeInfo.IsInterface &&
            !typeInfo.IsAbstract;
    }
}
