using BudgetPro.Server.Data;

namespace BudgetPro.Server.DTOs;

public class CategoryDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsIncome { get; set; }
    public int UserId { get; set; }
}

public static class CategoryConverter
{ 
    public static CategoryDTO ToDTO(this Category category)
    {
        if (category is null)
        {
            return new CategoryDTO();
        }

        return new CategoryDTO()
        {
            Id = category.Id,
            IsIncome = category.IsIncome,
            Name = category.Name,
            UserId = category.UserId
        };
    }
}
