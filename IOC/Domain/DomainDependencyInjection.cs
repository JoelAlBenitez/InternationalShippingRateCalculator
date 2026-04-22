namespace IOC.Domain;

using DomainValidators = global::Domain.Validators;
using Microsoft.Extensions.DependencyInjection;

public static class DomainDependencyInjection
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<DomainValidators.IBusinessValidator, DomainValidators.BusinessValidator>();

        return services;
    }
}
