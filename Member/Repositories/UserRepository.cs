using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Agency.Member.Interfaces;
using Agency.Data.MyContext;
using Agency.Member.Entities;

namespace Agency.Member.Repositories;
public class UserRepository : IUserRepository
{
    public readonly Context _context;
    public UserRepository(Context context)
    {
        _context = context;
    }
    public async Task<MemberEntity> GetUserById(Guid Id)
    {
        return await _context.Members.FirstOrDefaultAsync(a => a.Id == Id);
    }
    public async Task<IEnumerable<MemberEntity>> GetAllAsync()
    {
        return await _context.Members.ToListAsync();
    }

    public async Task<MemberEntity> AddAsync(MemberEntity user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        await _context.Members.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }
    public async Task UpdateAsync(MemberEntity user)
    {
        await _context.Members.AddAsync(user);
    }
    public async Task DeleteAsync(Guid Id)
    {
        var user = await GetUserById(Id);
        if (user != null)
        {
            _context.Members.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<MemberEntity> GetUserByEmail(string email)
    {
        var member = await _context.Members.FirstOrDefaultAsync(u => u.Email.Equals(email));
        return member;
    }
}