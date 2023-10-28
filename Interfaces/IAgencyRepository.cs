using Microsoft.AspNetCore.Mvc;
using Agency.Models.Entities.Agency;

namespace Agency.Interfaces;
public interface IAgencyRepository
{
    Task<AgencyEntity> GetAgencyById(Guid Id);
    Task<IEnumerable<AgencyEntity>> GetAllAsync();
    Task<AgencyEntity> AddAsync(AgencyEntity agency);
    Task UpdateAsync(AgencyEntity agency);
    Task DeleteAsync(Guid Id);
}
