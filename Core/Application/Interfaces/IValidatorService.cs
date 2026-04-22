namespace Application.Abstractions;

public interface IValidatorService
{
    void ValidateWeight(decimal weight);
    void ValidateCountryId(int countryId);
    void ValidateCountryName(string countryName);
}
