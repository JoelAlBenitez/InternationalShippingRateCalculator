namespace IOC.Infraestructure;

using global::Application.Abstractions;
using global::Infraestructure.Data;
using global::Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ShippingDbContext>(options =>
            options.UseSqlServer(connectionString)
        );

        services.AddScoped<ICountryRepository, CountryRepository>();

        return services;
    }
}
