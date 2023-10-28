using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Agency.Interfaces;
using Agency.Models.MyContext;
using Agency.Models.Entities.Member;

namespace Agency.Data.Repositories;
public class UserRepository : IUserRepository
{
    public readonly MyContext _context;
    public UserRepository(MyContext context)
    {
        _context = context;
    }
    public async Task<MemberEntity> GetUserById(Guid Id)
    {
        return await _context.Users.FirstOrDefaultAsync(a => a.Id == Id);
    }
    public async Task<IEnumerable<MemberEntity>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<MemberEntity> AddAsync(MemberEntity user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }
    public async Task UpdateAsync(MemberEntity user)
    {
        await _context.Users.AddAsync(user);
    }
    public async Task DeleteAsync(Guid Id)
    {
        var user = await GetUserById(Id);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}