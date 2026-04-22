namespace Application.Abstractions;

using Domain.ReadModels;

public interface ICountryRepository
{
    Task<IEnumerable<CountryReadModel>> GetAllAsync();
    Task<CountryReadModel?> GetByIdAsync(int id);
}
