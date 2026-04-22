namespace Infraestructure.Repositories;

using Application.Abstractions;
using Domain.ReadModels;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

public class CountryRepository : ICountryRepository
{
    private readonly ShippingDbContext _context;

    public CountryRepository(ShippingDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CountryReadModel>> GetAllAsync()
    {
        return await _context.Countrys
            .Select(c => new CountryReadModel
            {
                Id = c.Id,
                Name = c.Name,
                PriceSend = c.PriceSend
            })
            .ToListAsync();
    }

    public async Task<CountryReadModel?> GetByIdAsync(int id)
    {
        return await _context.Countrys
            .Where(c => c.Id == id)
            .Select(c => new CountryReadModel
            {
                Id = c.Id,
                Name = c.Name,
                PriceSend = c.PriceSend
            })
            .FirstOrDefaultAsync();
    }
}

