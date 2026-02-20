using System.Reflection;
using Fanoos.Common.Behaviors;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Fanoos.Common;

public static class ApplicationConfiguration {
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        params Assembly[] moduleAssemblies
    ) {
        services.AddMediatR(config => {
            config.RegisterServicesFromAssemblies(moduleAssemblies);

            config.AddOpenBehavior(typeof(ExceptionHandlingPipelineBehavior<,>));
        });

        services.AddValidatorsFromAssemblies(moduleAssemblies, includeInternalTypes: true);

        return services;
    }
}
