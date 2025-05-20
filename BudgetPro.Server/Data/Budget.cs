namespace BudgetPro.Server.Data;

public partial class Budget
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int? CategoryId { get; set; }

    public double Amount { get; set; }

    public DateOnly? EndDate { get; set; }

    public DateOnly? StartDate { get; set; }

    public string? Name { get; set; }

    public virtual Category? Category { get; set; }

    public virtual User User { get; set; } = null!;
}
