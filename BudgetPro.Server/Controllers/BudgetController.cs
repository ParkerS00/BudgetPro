using BudgetPro.Server.DTOs;
using BudgetPro.Server.Interfaces;
using BudgetPro.Server.Requests.AddRequests;
using BudgetPro.Server.Requests.GetRequests;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPro.Server.Controllers;
[ApiController]
[Route("[controller]")]
public class BudgetController
{
    private IBudgetService budgetService;
    public BudgetController(IBudgetService budgetService)
    {
        this.budgetService = budgetService;
    }

    [HttpGet("GetAll")]
    public async Task<List<BudgetDTO>> GetAllBudgets()
    {
        return await budgetService.GetAllBudgets();
    }

    [HttpPost("Add")]
    public async Task<BudgetDTO> AddNewBudget(AddBudgetRequest request)
    {
        return await budgetService.AddNewBudget(request);
    }

    [HttpPost("GetById")]
    public async Task<BudgetDTO> GetBudgetById(FindBudgetRequest request)
    {
        return await budgetService.GetBudgetById(request);
    }

    [HttpPost("GetByUser")]
    public async Task<List<BudgetDTO>> GetBudgetsByUser(FindBudgetRequest request)
    {
        return await budgetService.GetBudgetsByUser(request);
    }

    [HttpPost("GetByCategory")]
    public async Task<List<BudgetDTO>> GetBudgetsByCategory(FindBudgetRequest request)
    {
        return await budgetService.GetBudgetsByCategory(request);
    }

    [HttpPost("GetByTimeFrame")]
    public async Task<BudgetDTO> GetBudgetByTimeFrame(FindBudgetRequest request)
    {
        return await budgetService.GetBudgetByTimeFrame(request);
    }

    [HttpPost("GetBudgetByName")]
    public async Task<BudgetDTO> GetBudgetByName(FindBudgetRequest request)
    {
        return await budgetService.GetBudgetByName(request);
    }
}
