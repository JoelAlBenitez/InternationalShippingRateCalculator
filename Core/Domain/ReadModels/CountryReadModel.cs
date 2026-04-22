namespace Domain.ReadModels;

public class CountryReadModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal PriceSend { get; set; }
}
