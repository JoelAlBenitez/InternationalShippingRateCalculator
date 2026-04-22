namespace Domain.Validators;

public interface IBusinessValidator
{
    
    void ValidateWeight(decimal weight);

    void ValidateCountry(string countryName);
}
