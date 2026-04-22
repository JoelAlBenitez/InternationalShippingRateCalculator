using Application.Abstractions;
using Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TariffController : ControllerBase
{
    private readonly ITariffService _tariffService;

    public TariffController(ITariffService tariffService)
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
