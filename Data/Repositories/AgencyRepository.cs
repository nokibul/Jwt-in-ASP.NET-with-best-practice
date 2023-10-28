using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Agency.Interfaces;
using Agency.Models.MyContext;
using Agency.Models.Entities.Agency;

namespace Agency.Data.Repositories;
public class AgencyRepository : IAgencyRepository
{
    public readonly MyContext _context;
    public AgencyRepository(MyContext context)
    {
        _context = context;
    }
    public async Task<AgencyEntity> GetAgencyById(Guid Id)
    {
        return await _context.Agencies.FirstOrDefaultAsync(a => a.Id == Id);
    }
    public async Task<IEnumerable<AgencyEntity>> GetAllAsync()
    {
        return await _context.Agencies.ToListAsync();
    }

    public async Task<AgencyEntity> AddAsync(AgencyEntity agency)
    {
        if (agency == null)
        {
            throw new ArgumentNullException(nameof(agency));
        }

        await _context.Agencies.AddAsync(agency);
        await _context.SaveChangesAsync();
        return agency;
    }
    public async Task UpdateAsync(AgencyEntity agency)
    {
        await _context.Agencies.AddAsync(agency);
    }
    public async Task DeleteAsync(Guid Id)
    {
        var agency = await GetAgencyById(Id);
        if (agency != null)
        {
            _context.Agencies.Remove(agency);
            await _context.SaveChangesAsync();
        }
    }
}