using System;
using System.Collections.Generic;

namespace BudgetPro.Server.Data;

public partial class Transaction
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int CategoryId { get; set; }

    public double Amount { get; set; }

    public string? Description { get; set; }

    public DateOnly DateOccured { get; set; }

    public bool IsRecurring { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
