namespace Domain.Rules;

public class IndiaTariffRule : ITariffRule
{
    public string CountryName => "India";

    public decimal CalculateTariff(decimal weight)
    {
        return weight * 5;
    }
}
