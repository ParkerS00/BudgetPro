using BudgetPro.Server.Data;

namespace BudgetPro.Server.DTOs;

public class UserDTO
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? Email { get; set; }
}

public static class UserConverter
{
    public static UserDTO ToDTO(this User user)
    {
        if (user is null)
        {
            return new UserDTO();
        }

        return new UserDTO()
        {
            CreatedAt = user.CreatedAt,
            Email = user.Email,
            Id = user.Id
        };
    }
}
