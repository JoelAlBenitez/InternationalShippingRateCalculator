namespace Domain.Entities;


public class Shipment
{
    public int CountryId { get; set; }
    public decimal Weight { get; set; }
    public Country? Country { get; set; }
}
