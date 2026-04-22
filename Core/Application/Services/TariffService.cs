namespace Application.Services;

using Application.Abstractions;
using Application.Dtos;
using Domain.Common;
using Domain.ReadModels;
using Domain.Rules;
using Domain.Validators;

public class TariffService
{
    private readonly ICountryRepository _countryRepository;
    private readonly IBusinessValidator _businessValidator;
    private readonly ITariffRule[] _tariffRules;

    public TariffService(ICountryRepository countryRepository, IBusinessValidator businessValidator)
    {
        _countryRepository = countryRepository;
        _businessValidator = businessValidator;
        _tariffRules = new ITariffRule[]
        {
            new IndiaTariffRule(),
            new USTariffRule(),
            new UKTariffRule()
        };
    }

    public async Task<CalculateTariffResponse> CalculateTariffAsync(CalculateTariffRequest request)
    {
        try
        {
            _businessValidator.ValidateWeight(request.Weight);

            var country = await _countryRepository.GetByIdAsync(request.CountryId);

            if (country == null)
            {
                throw new BusinessException(
                    BusinessErrorCode.CountryNotFound,
                    $"El país con ID {request.CountryId} no fue encontrado."
                );
            }

            _businessValidator.ValidateCountry(country.Name);

            var tariffRule = _tariffRules.FirstOrDefault(rule =>
                rule.CountryName.Equals(country.Name, StringComparison.OrdinalIgnoreCase)
            );

            if (tariffRule == null)
            {
                throw new BusinessException(
                    BusinessErrorCode.UnsupportedCountry,
                    $"No hay regla de tarifa configurada para {country.Name}."
                );
            }

            var totalCost = tariffRule.CalculateTariff(request.Weight);

            var result = new TariffResultModel
            {
                CountryId = country.Id,
                CountryName = country.Name,
                Weight = request.Weight,
                TotalCost = totalCost,
                TariffPerKg = totalCost / request.Weight
            };

            return new CalculateTariffResponse
            {
                Success = true,
                Message = "Cálculo de tarifa realizado exitosamente.",
                Data = MapToDto(result)
            };
        }
        catch (BusinessException ex)
        {
            return new CalculateTariffResponse
            {
                Success = false,
                Message = ex.Message,
                ErrorCode = (int)ex.ErrorCode
            };
        }
        catch (Exception ex)
        {
            return new CalculateTariffResponse
            {
                Success = false,
                Message = "Ha ocurrido un error inesperado. Por favor, intente de nuevo.",
                ErrorCode = (int)BusinessErrorCode.ValidationError
            };
        }
    }

    public async Task<IEnumerable<CountryReadModel>> GetAllCountriesAsync()
    {
        try
        {
            return await _countryRepository.GetAllAsync();
        }
        catch (Exception)
        {
            return Enumerable.Empty<CountryReadModel>();
        }
    }

    private static TariffResultDto MapToDto(TariffResultModel model)
    {
        return new TariffResultDto
        {
            CountryId = model.CountryId,
            CountryName = model.CountryName,
            Weight = model.Weight,
            TotalCost = model.TotalCost,
            TariffPerKg = model.TariffPerKg
        };
    }
}
