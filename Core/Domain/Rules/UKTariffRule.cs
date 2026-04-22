namespace Domain.Rules;


public class UKTariffRule : ITariffRule
{
    public string CountryName => "UK";

    public decimal CalculateTariff(decimal weight)
    {
        return weight * 10;
    }
}
