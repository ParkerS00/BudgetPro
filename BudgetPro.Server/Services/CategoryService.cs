using BudgetPro.Server.Data;
using BudgetPro.Server.DTOs;
using BudgetPro.Server.Interfaces;
using BudgetPro.Server.Requests.AddRequests;
using BudgetPro.Server.Requests.GetRequests;
using Microsoft.EntityFrameworkCore;

namespace BudgetPro.Server.Services;

public class CategoryService : ICategoryService
{
    private readonly IDbContextFactory<BudgetDbContext> dbContextFactory;

    public CategoryService(IDbContextFactory<BudgetDbContext> dbContextFactory)
    {
        this.dbContextFactory = dbContextFactory;
    }

    public async Task<CategoryDTO> AddCategory(AddCategoryRequest request)
    {
        if (request is null)
        {
            return new CategoryDTO();
        }

        using var context = await dbContextFactory.CreateDbContextAsync();

        var possibleCategory = await context.Categories
            .Where(x => x.Name == request.Name)
            .FirstOrDefaultAsync();

        if (possibleCategory is not null)
        {
            return new CategoryDTO();
        }

        Category newCategory = new Category()
        {
            IsIncome = request.IsIncome,
            Name = request.Name ?? "",
            UserId = request.UserId,
        };

        await context.Categories.AddAsync(newCategory);
        await context.SaveChangesAsync();

        return newCategory.ToDTO();
    }

    public async Task<List<CategoryDTO>> GetAllCategories()
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        return await context.Categories
            .Select(x => x.ToDTO())
            .ToListAsync();
    }

    public async Task<CategoryDTO> GetCategoryById(FindCategoryRequest request)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        return await context.Categories
            .Where(x => x.Id == request.Id)
            .Select(x => x.ToDTO())
            .FirstOrDefaultAsync() ?? new CategoryDTO();
    }

    public async Task<CategoryDTO> GetCategoryByName(FindCategoryRequest request)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        return await context.Categories
            .Where(x => x.Name == request.Name && x.UserId == request.UserId)
            .Select(x => x.ToDTO())
            .FirstOrDefaultAsync() ?? new CategoryDTO();
    }


}
