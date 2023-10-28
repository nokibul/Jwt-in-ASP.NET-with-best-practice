using Microsoft.AspNetCore.Mvc;
using Agency.Models.Entities.Member;

namespace Agency.Interfaces;
public interface IUserRepository
{
    Task<MemberEntity> GetUserById(Guid Id);
    Task<IEnumerable<MemberEntity>> GetAllAsync();
    Task<MemberEntity> AddAsync(MemberEntity member);
    Task UpdateAsync(MemberEntity member);
    Task DeleteAsync(Guid Id);
}
