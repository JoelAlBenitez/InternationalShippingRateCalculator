namespace Application.Abstractions;

using Application.Dtos;
using Domain.ReadModels;

public interface ITariffService
{
    Task<CalculateTariffResponse> CalculateTariffAsync(CalculateTariffRequest request);
    Task<IEnumerable<CountryReadModel>> GetAllCountriesAsync();
}
