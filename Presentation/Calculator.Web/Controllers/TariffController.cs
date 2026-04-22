using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TariffController : ControllerBase
{
    private readonly TariffService _tariffService;

    public TariffController(TariffService tariffService)
    {
        _tariffService = tariffService;
    }

    [HttpPost("calculate")]
    public async Task<IActionResult> Calculate([FromBody] CalculateTariffRequest request)
    {
        var response = await _tariffService.CalculateTariffAsync(request);
        return Ok(response);
    }

    [HttpGet("countries")]
    public async Task<IActionResult> GetCountries()
    {
        var countries = await _tariffService.GetAllCountriesAsync();
        return Ok(countries);
    }
}
