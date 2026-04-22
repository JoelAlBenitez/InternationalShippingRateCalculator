namespace Domain.Rules;


public class USTariffRule : ITariffRule
{
    public string CountryName => "US";

    public decimal CalculateTariff(decimal weight)
    {
        return weight * 8;
    }
}
