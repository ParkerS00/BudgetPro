using BudgetPro.Server.DTOs;
using BudgetPro.Server.Interfaces;
using BudgetPro.Server.Requests.AddRequests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BudgetPro.Server.Controllers;

[ApiController]
[Route("Controller")]
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
    public async Task<UserDTO> RegisterNewUser(RegisterUserRequest request)
    {
        return await userService.RegisterNewUser(request);
    }
}
