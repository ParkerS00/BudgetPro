namespace BudgetPro.Server.Requests.GetRequests;

public class FindCategoryRequest
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int UserId { get; set; }
}
