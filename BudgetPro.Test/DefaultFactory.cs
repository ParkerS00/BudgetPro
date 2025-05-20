using BudgetPro.Server.Data;

namespace BudgetPro.Test;

public static class DefaultFactory
{
    public static Budget CreateTestBudget()
    {
        return new Budget()
        {
            Amount = 100,
            Category = new Category(),
            CategoryId = 1,
            Id = 1,
            EndDate = new DateOnly(2025, 5, 8),
            User = new User(),
            UserId = 1
        };
    }

    public static User CreateTestUser()
    {
        return new User()
        {
            CreatedAt = new DateTime(2025, 5, 8),
            Email = "test@gmail.com",
            Id = 1
        };
    }

    public static Category CreateTestCategory()
    {
        return new Category()
        {
            Id = 1,
            IsIncome = true,
            Name = "Salary",
            User = new User(),
            UserId = 1
        };
    }

    public static Transaction CreateTestTransaction()
    {
        return new Transaction()
        {
            Amount = 100,
            Category = new Category(),
            CategoryId = 1,
            DateOccured = new DateOnly(2025, 5, 8),
            Description = "Test Description",
            Id = 1,
            IsRecurring = true,
            User = new User(),
            UserId = 1
        };
    }
}
