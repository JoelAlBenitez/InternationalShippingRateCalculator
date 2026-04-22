namespace Domain.Entities;


public class Country
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal PriceSend { get; set; }
}
