using BudgetPro.Server.Data;
using BudgetPro.Server.DTOs;
using BudgetPro.Server.Interfaces;
using BudgetPro.Server.Requests.AddRequests;
using BudgetPro.Server.Requests.GetRequests;
using Microsoft.EntityFrameworkCore;

namespace BudgetPro.Server.Services;

public class BudgetService : IBudgetService
{
    private readonly IDbContextFactory<BudgetDbContext> dbContextFactory;
    public BudgetService(IDbContextFactory<BudgetDbContext> dbContextFactory)
    {
        this.dbContextFactory = dbContextFactory;
    }

    public async Task<BudgetDTO> AddNewBudget(AddBudgetRequest request)
    {
        if (request is null)
        {
            return new BudgetDTO();
        }

        using var context = await dbContextFactory.CreateDbContextAsync();

        var possibleBudget = await context.Budgets
            .Where(x => x.Name == request.Name && x.CategoryId == request.CategoryId)
            .FirstOrDefaultAsync();

        if (possibleBudget is not null)
        {
            return new BudgetDTO();
        }

        Budget newBudget = new Budget()
        {
            Amount = request.Amount,
            CategoryId = request.CategoryId,
            Name = request.Name,
            Timeframe = request.TimeFrame,
            UserId = request.UserId
        };

        await context.AddAsync(newBudget);
        await context.SaveChangesAsync();

        return newBudget.ToDTO();
    }

    public async Task<List<BudgetDTO>> GetAllBudgets()
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        return await context.Budgets
            .Include(x => x.User)
            .Include(x => x.Category)
            .Select(x => x.ToDTO())
            .ToListAsync();
    }

    public async Task<BudgetDTO> GetBudgetById(FindBudgetRequest request)
    {
        if (request is null || request.Id <= 0)
        {
            return new BudgetDTO();
        }

        using var context = await dbContextFactory.CreateDbContextAsync();

        return await context.Budgets
            .Include(x => x.User)
            .Include(x => x.Category)
            .Where(x => x.Id == request.Id)
            .Select(x => x.ToDTO())
            .FirstOrDefaultAsync() ?? new BudgetDTO();
    }

    public async Task<BudgetDTO> GetBudgetByName(FindBudgetRequest request)
    {
        if (request is null || request.Name is null)
        {
            return new BudgetDTO();
        }

        using var context = await dbContextFactory.CreateDbContextAsync();

        return await context.Budgets
            .Include(x => x.User)
            .Include(x => x.Category)
            .Where(x => x.Name == request.Name)
            .Select(x => x.ToDTO())
            .FirstOrDefaultAsync() ?? new BudgetDTO();
    }

    public async Task<BudgetDTO> GetBudgetByTimeFrame(FindBudgetRequest request)
    {
        if (request is null || request.TimeFrame is null || request.UserId <= 0)
        {
            return new BudgetDTO();
        }

        using var context = await dbContextFactory.CreateDbContextAsync();

        return await context.Budgets
            .Include(x => x.User)
            .Include(x => x.Category)
            .Where(x => x.UserId == request.UserId && x.Timeframe == request.TimeFrame)
            .Select(x => x.ToDTO())
            .FirstOrDefaultAsync() ?? new BudgetDTO();
    }

    public async Task<List<BudgetDTO>> GetBudgetsByCategory(FindBudgetRequest request)
    {
        if (request is null || request.CategoryId <= 0)
        {
            return new List<BudgetDTO>();
        }

        using var context = await dbContextFactory.CreateDbContextAsync();

        return await context.Budgets
            .Include(x => x.User)
            .Include(x => x.Category)
            .Where(x => x.CategoryId == request.CategoryId)
            .Select(x => x.ToDTO())
            .ToListAsync();
    }

    public async Task<List<BudgetDTO>> GetBudgetsByUser(FindBudgetRequest request)
    {
        if (request is null || request.UserId <= 0)
        {
            return new List<BudgetDTO>();
        }

        using var context = await dbContextFactory.CreateDbContextAsync();

        return await context.Budgets
            .Include(x => x.User)
            .Include(x => x.Category)
            .Where(x => x.UserId == request.UserId)
            .Select(x => x.ToDTO())
            .ToListAsync();
    }
}
