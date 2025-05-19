using BudgetPro.Server.DTOs;
using BudgetPro.Server.Requests.AddRequests;
using BudgetPro.Server.Requests.GetRequests;

namespace BudgetPro.Server.Interfaces;

public interface IBudgetService
{
    public Task<List<BudgetDTO>> GetAllBudgets();
    public Task<BudgetDTO> AddNewBudget(AddBudgetRequest request);
    public Task<BudgetDTO> GetBudgetById(FindBudgetRequest request);
    public Task<List<BudgetDTO>> GetBudgetsByUser(FindBudgetRequest request);
    public Task<List<BudgetDTO>> GetBudgetsByCategory(FindBudgetRequest request);
    public Task<BudgetDTO> GetBudgetByTimeFrame(FindBudgetRequest request);
    public Task<BudgetDTO> GetBudgetByName(FindBudgetRequest request);
}
