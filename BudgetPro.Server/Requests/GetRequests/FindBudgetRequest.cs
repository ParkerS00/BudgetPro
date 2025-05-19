namespace BudgetPro.Server.Requests.GetRequests;

public class FindBudgetRequest
{
    public int? Id { get; set; }
    public int? UserId { get; set; }
    public int? CategoryId { get; set; }
    public DateOnly? TimeFrame { get; set; }
    public string? Name { get; set; }
}
