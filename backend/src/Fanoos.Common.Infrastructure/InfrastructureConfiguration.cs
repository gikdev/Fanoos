using Fanoos.Common.Application.Caching;
using Fanoos.Common.Application.Clock;
using Fanoos.Common.Application.Data;
using Fanoos.Common.Application.EventBus;
using Fanoos.Common.Infrastructure.Authentication;
using Fanoos.Common.Infrastructure.Authorization;
using Fanoos.Common.Infrastructure.Caching;
using Fanoos.Common.Infrastructure.Clock;
using Fanoos.Common.Infrastructure.Data;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;
using Fanoos.Common.Infrastructure.Interceptors;

namespace Fanoos.Common.Infrastructure;

public static class InfrastructureConfiguration {
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        Action<IRegistrationConfigurator>[] moduleConfigureConsumers,
        string databaseConnectionString
    ) {
        services.AddAuthenticationInternal();

        services.AddAuthorizationInternal();

        NpgsqlDataSource npgsqlDataSource = new NpgsqlDataSourceBuilder(databaseConnectionString).Build();
        services.TryAddSingleton(npgsqlDataSource);

        services.TryAddScoped<IDbConnectionFactory, DbConnectionFactory>();

        services.TryAddSingleton<PublishDomainEventsInterceptor>();

        services.TryAddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddDistributedMemoryCache();

        services.TryAddSingleton<ICacheService, CacheService>();

        services.TryAddSingleton<IEventBus, EventBus.EventBus>();

        services.AddMassTransit(configure => {
            foreach (Action<IRegistrationConfigurator> configureConsumer in moduleConfigureConsumers) {
                configureConsumer(configure);
            }

            configure.SetKebabCaseEndpointNameFormatter();

            configure.UsingInMemory((context, cfg) => {
                cfg.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}
