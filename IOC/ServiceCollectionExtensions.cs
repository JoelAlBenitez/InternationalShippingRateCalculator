namespace IOC;

using IOC.Application;
using IOC.Domain;
using IOC.Infraestructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDependencyInjection(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDomainServices();
        services.AddApplicationServices();
        services.AddInfrastructureServices(configuration);

        return services;
    }
}
