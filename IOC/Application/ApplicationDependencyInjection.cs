namespace IOC.Application;

using global::Application.Abstractions;
using global::Application.Services;
using Microsoft.Extensions.DependencyInjection;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IValidatorService, ValidatorService>();
        services.AddScoped<ITariffService, TariffService>();

        return services;
    }
}
