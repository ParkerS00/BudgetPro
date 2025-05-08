using BudgetPro.Server.Data;
using BudgetPro.Server.DTOs;
using BudgetPro.Server.Interfaces;
using Microsoft.EntityFrameworkCore;
using BudgetPro.Server.Requests.AddRequests;

namespace BudgetPro.Server.Services;

public class UserService : IUserService
{
    private readonly IDbContextFactory<BudgetDbContext> dbContextFactory;

    public UserService(IDbContextFactory<BudgetDbContext> dbContextFactory)
    {
        this.dbContextFactory = dbContextFactory;
    }

    public async Task<List<UserDTO>> GetAllUsers()
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        return await context.Users
            .Select(x => x.ToDTO())
            .ToListAsync();
    }

    public async Task<UserDTO> RegisterNewUser(RegisterUserRequest request)
    {
        if (request is null)
        {
            return new UserDTO();
        }

        using var context = await dbContextFactory.CreateDbContextAsync();

        var existingUser = await context.Users
            .Where(x => x.Email == request.Email)
            .FirstOrDefaultAsync();

        if (existingUser is not null)
        {
            return new UserDTO();
        }

        var newUser = new User()
        {
            CreatedAt = DateTime.UtcNow,
            Email = request.Email,
        };

        await context.Users.AddAsync(newUser);
        await context.SaveChangesAsync();

        return newUser.ToDTO();
    }
}
