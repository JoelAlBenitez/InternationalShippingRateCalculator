namespace Domain.Validators;

using Domain.Common;
using Domain.Rules;

public class BusinessValidator : IBusinessValidator
{
    private const decimal MaxWeight = 70m;
    private readonly ITariffRule[] _availableRules;

    public BusinessValidator()
    {
        _availableRules = new ITariffRule[]
        {
            new IndiaTariffRule(),
            new USTariffRule(),
            new UKTariffRule()
        };
    }

    public void ValidateWeight(decimal weight)
    {
        if (weight <= 0)
        {
            throw new BusinessException(
                BusinessErrorCode.InvalidWeight,
                "El peso del envío debe ser mayor a cero."
            );
        }

        if (weight > MaxWeight)
        {
            throw new BusinessException(
                BusinessErrorCode.InvalidWeight,
                $"El peso del envío no puede exceder {MaxWeight} kg. El comercio electrónico no permite envíos superiores a este límite."
            );
        }
    }

    public void ValidateCountry(string countryName)
    {
        if (string.IsNullOrWhiteSpace(countryName))
        {
            throw new BusinessException(
                BusinessErrorCode.ValidationError,
                "El nombre del país no puede estar vacío."
            );
        }

        var isSupported = _availableRules.Any(rule => 
            rule.CountryName.Equals(countryName, StringComparison.OrdinalIgnoreCase)
        );

        if (!isSupported)
        {
            throw new BusinessException(
                BusinessErrorCode.UnsupportedCountry,
                $"El país '{countryName}' no es soportado. Países disponibles: India, US, UK."
            );
        }
    }
}
