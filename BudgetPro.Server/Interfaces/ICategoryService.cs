using BudgetPro.Server.DTOs;
using BudgetPro.Server.Requests.AddRequests;
using BudgetPro.Server.Requests.GetRequests;

namespace BudgetPro.Server.Interfaces;

public interface ICategoryService
{
    public Task<List<CategoryDTO>> GetAllCategories();
    public Task<CategoryDTO> AddCategory(AddCategoryRequest request);
    public Task<CategoryDTO> GetCategoryByName(FindCategoryRequest request);
    public Task<CategoryDTO> GetCategoryById(FindCategoryRequest request);
}
