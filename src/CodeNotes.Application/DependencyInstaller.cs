using CodeNotes.Domain.DependencyInjection;
using FluentValidation;
using MediatR.NotificationPublishers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeNotes.Application;
public class DependencyInstaller : IDependencyInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(DependencyInstaller).Assembly);
            config.NotificationPublisher = new TaskWhenAllPublisher();
            config.NotificationPublisherType = typeof(TaskWhenAllPublisher);
            config.Lifetime = ServiceLifetime.Transient;
        });
        services.AddValidatorsFromAssembly(typeof(DependencyInstaller).Assembly, includeInternalTypes: true);
    }
}
