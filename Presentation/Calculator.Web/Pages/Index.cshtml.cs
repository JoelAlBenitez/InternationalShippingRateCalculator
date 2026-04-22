using Application.Abstractions;
using Domain.ReadModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Calculator.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ITariffService _tariffService;

    public IndexModel(ITariffService tariffService)
    {
        _tariffService = tariffService;
    }

    public IEnumerable<CountryReadModel> Countries { get; private set; } = Enumerable.Empty<CountryReadModel>();

    public async Task OnGetAsync()
    {
        Countries = await _tariffService.GetAllCountriesAsync();
    }
}
