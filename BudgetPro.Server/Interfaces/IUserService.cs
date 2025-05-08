using BudgetPro.Server.DTOs;
using BudgetPro.Server.Requests.AddRequests;

namespace BudgetPro.Server.Interfaces;

public interface IUserService
{
    public Task<List<UserDTO>> GetAllUsers();
    public Task<UserDTO> RegisterNewUser(RegisterUserRequest request);
}
