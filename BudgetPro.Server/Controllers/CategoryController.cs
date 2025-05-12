using BudgetPro.Server.DTOs;
using BudgetPro.Server.Interfaces;
using BudgetPro.Server.Requests.AddRequests;
using BudgetPro.Server.Requests.GetRequests;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPro.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : Controller
{
    private ICategoryService categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        this.categoryService = categoryService;
    }

    [HttpGet("GetAll")]
    public async Task<List<CategoryDTO>> GetAllCategories()
    {
        return await categoryService.GetAllCategories();
    }

    [HttpPost("Add")]
    public async Task<IActionResult> AddNewCategory(AddCategoryRequest request)
    {
        var result = await categoryService.AddCategory(request);

        if (result.Name is null)
        {
            return Conflict(new { message = "Category already exists" });
        }

        return Ok(new { message = "Category created successfully" });
    }

    [HttpPost("GetByName")]
    public async Task<CategoryDTO> GetCategoryByEmail(FindCategoryRequest request)
    {
        return await categoryService.GetCategoryByName(request);
    }

    [HttpPost("GetById")]
    public async Task<CategoryDTO> GetCategoryById(FindCategoryRequest request)
    {
        return await categoryService.GetCategoryById(request);
    }
}
