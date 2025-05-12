namespace BudgetPro.Server.Requests.AddRequests;

public class AddCategoryRequest
{
    public string? Name { get; set; }
    public bool IsIncome { get; set; }
    public int UserId { get; set; }
}
