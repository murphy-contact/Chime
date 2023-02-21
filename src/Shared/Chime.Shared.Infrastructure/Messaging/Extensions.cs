using Chime.Shared.Abstractions.Messaging;
using Chime.Shared.Infrastructure.Messaging.Broker;
using Microsoft.Extensions.DependencyInjection;

namespace Chime.Shared.Infrastructure.Messaging;

public static class Extensions
{
    private const string SectionName = "messaging";

    public static IServiceCollection AddMessaging(this IServiceCollection services)
    {
        services.AddTransient<IMessageBroker, InMemoryMessageBroker>();

        return services;
    }
}