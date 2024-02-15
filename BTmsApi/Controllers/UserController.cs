using BTmsApi.DataTransferObjects;
using BTmsApi.Models;
using BTmsApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BTmsApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAllUsers()
    {
        return await _userService.GetAllUsers();
    }

    [HttpPost]
    public ActionResult<AuthPas> SignUpNewUser(User user)
    {
        return _userService.SignUpNewUser(user);
    }

}
