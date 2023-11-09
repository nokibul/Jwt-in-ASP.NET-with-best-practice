using Microsoft.AspNetCore.Mvc;
using Agency.Member.Entities;

namespace Agency.Member.Interfaces;
public interface IUserRepository
{
    Task<MemberEntity> GetUserByEmail(string email);
    Task<MemberEntity> GetUserById(Guid Id);
    Task<IEnumerable<MemberEntity>> GetAllAsync();
    Task<MemberEntity> AddAsync(MemberEntity member);
    Task UpdateAsync(MemberEntity member);
    Task DeleteAsync(Guid Id);
}
