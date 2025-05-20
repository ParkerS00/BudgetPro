namespace BudgetPro.Server.Requests.AddRequests;

public class AddBudgetRequest
{
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public double Amount { get; set; }
    public DateOnly EndDate { get; set; }
    public DateOnly StartDate { get; set; }
    public string Name { get; set; } = DateTime.Today.ToString();
}
