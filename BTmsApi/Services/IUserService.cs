using BTmsApi.DataTransferObjects;
using BTmsApi.Models;

namespace BTmsApi.Services;

public interface IUserService
{
    public Task<List<User>> GetAllUsers();

    public Task<User> GetUserById(int id);

    public AuthPas SignUpNewUser(User user);

    public Task<User> UpdateUser(User user);

    public void DeleteUser(int id);
}
