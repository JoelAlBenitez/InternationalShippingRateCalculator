namespace Domain.ReadModels;

public class TariffResultModel
{
   
    public int CountryId { get; set; }
  
    public string CountryName { get; set; } = string.Empty;
   
    public decimal Weight { get; set; }
  
    public decimal TotalCost { get; set; }

    public decimal TariffPerKg { get; set; }
}
