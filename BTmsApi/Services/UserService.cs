using BTmsApi.DataTransferObjects;
using BTmsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BTmsApi.Services;

public class UserService: IUserService
{
    private readonly SharedContext _context;

    public UserService(SharedContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUserById(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public AuthPas SignUpNewUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user.getAuthPas();
    }

    public async Task<User> UpdateUser(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return await GetUserById(user.Id);
    }

    public async void DeleteUser(int id)
    {
        var user = await GetUserById(id);
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}
