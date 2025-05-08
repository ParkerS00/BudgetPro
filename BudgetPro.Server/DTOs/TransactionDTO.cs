using BudgetPro.Server.Data;

namespace BudgetPro.Server.DTOs;

public class TransactionDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public double Amount { get; set; }
    public string? Description { get; set; }
    public DateOnly DateOccured { get; set; }
    public bool IsRecurring { get; set; }
    public CategoryDTO Category { get; set; } = new();
    public UserDTO User { get; set; } = new();
}

public static class TransactionConverter
{
    public static TransactionDTO ToDTO(this Transaction transaction)
    {
        if (transaction is null)
        {
            return new TransactionDTO();
        }

        return new TransactionDTO()
        {
            Amount = transaction.Amount,
            Category = transaction.Category.ToDTO(),
            CategoryId = transaction.CategoryId,
            DateOccured = transaction.DateOccured,
            Description = transaction.Description,
            Id = transaction.Id,
            IsRecurring = transaction.IsRecurring,
            User = transaction.User.ToDTO(),
            UserId = transaction.UserId
        };
    }
}
