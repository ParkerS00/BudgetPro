using BudgetPro.Server.DTOs;
using BudgetPro.Server.Interfaces;
using BudgetPro.Server.Requests.AddRequests;
using BudgetPro.Server.Requests.GetRequests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BudgetPro.Server.Controllers;

[ApiController]
[Route("[Controller]")]
public class UserController : Controller
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpGet("GetAll")]
    public async Task<List<UserDTO>> GetAllUsers()
    {
        return await userService.GetAllUsers();
    }

    [HttpPost("AddUser")]
    public async Task<IActionResult> RegisterNewUser(RegisterUserRequest request)
    {
        var result = await userService.RegisterNewUser(request);

        if (result.Email is null)
        {
            return Conflict(new { message = "User already exists" });
        }

        return Ok(new { message = "User Created successfully" });
    }

    [HttpPost("GetByEmail")]
    public async Task<UserDTO> GetUserByEmail(FindUserRequest request)
    {
        return await userService.GetUserByEmail(request.Email ?? "");
    }

    [HttpPost("GetById")]
    public async Task<UserDTO> GetUserById(int id)
    {
        return await userService.GetUserById(id);
    }
}
