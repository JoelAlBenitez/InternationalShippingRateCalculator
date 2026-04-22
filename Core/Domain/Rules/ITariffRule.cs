namespace Domain.Rules;

public interface ITariffRule
{
    string CountryName { get; }

   
    decimal CalculateTariff(decimal weight);
}
