namespace Application.Services;

using Application.Abstractions;
using Domain.Common;
using Domain.Validators;

public class ValidatorService : IValidatorService
{
    private readonly IBusinessValidator _businessValidator;

    public ValidatorService(IBusinessValidator businessValidator)
    {
        _businessValidator = businessValidator;
    }

    public void ValidateWeight(decimal weight)
    {
        _businessValidator.ValidateWeight(weight);
    }

    public void ValidateCountryName(string countryName)
    {
        _businessValidator.ValidateCountry(countryName);
    }

    public void ValidateCountryId(int countryId)
    {
        if (countryId <= 0)
        {
            throw new BusinessException(
                BusinessErrorCode.ValidationError,
                "El ID del país debe ser mayor a cero."
            );
        }
    }
}
