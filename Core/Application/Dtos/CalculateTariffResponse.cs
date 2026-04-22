namespace Application.Dtos;

public class CalculateTariffResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public TariffResultDto? Data { get; set; }
    public int? ErrorCode { get; set; }
}

public class TariffResultDto
{
    public int CountryId { get; set; }
    public string CountryName { get; set; } = string.Empty;
    public decimal Weight { get; set; }
    public decimal TotalCost { get; set; }
    public decimal TariffPerKg { get; set; }
}
