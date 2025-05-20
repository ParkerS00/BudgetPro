using BudgetPro.Server.Data;

namespace BudgetPro.Server.DTOs;

public class BudgetDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int? CategoryId { get; set; }
    public double Amount { get; set; }
    public DateOnly? EndDate { get; set; }
    public DateOnly? StartDate { get; set; }
    public string? Name { get; set; }
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
            EndDate = budget.EndDate,
            StartDate = budget.StartDate,
            Name = budget.Name,
            User = budget.User.ToDTO(),
            UserId = budget.UserId
        };
    }
}

