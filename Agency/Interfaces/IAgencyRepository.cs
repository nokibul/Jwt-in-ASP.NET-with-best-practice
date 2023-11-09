using Microsoft.AspNetCore.Mvc;
using Agency.Agency.Entities;

namespace Agency.Agency.Interfaces;
public interface IAgencyRepository
{
    Task<AgencyEntity> GetAgencyById(Guid Id);
    Task<IEnumerable<AgencyEntity>> GetAllAsync();
    Task<AgencyEntity> AddAsync(AgencyEntity agency);
    Task UpdateAsync(AgencyEntity agency);
    Task DeleteAsync(Guid Id);
}
