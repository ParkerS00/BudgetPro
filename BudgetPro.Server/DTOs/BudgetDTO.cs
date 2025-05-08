using BudgetPro.Server.Data;

namespace BudgetPro.Server.DTOs;

public class BudgetDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int? CategoryId { get; set; }
    public double Amount { get; set; }
    public DateOnly? TimeFrame { get; set; }
    public CategoryDTO? Category { get; set; } = new();
    public UserDTO User { get; set; } = new();
}

public static class BudgetConverter
{
    public static BudgetDTO ToDTO(this Budget budget)
    {
        if (budget is null)
        {
            return new BudgetDTO();
        }

        return new BudgetDTO()
        {
            Amount = budget.Amount,
            Category = budget.Category?.ToDTO(),
            CategoryId = budget.CategoryId,
            Id = budget.Id,
            TimeFrame = budget.Timeframe,
            User = budget.User.ToDTO(),
            UserId = budget.UserId
        };
    }
}

