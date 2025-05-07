using System;
using System.Collections.Generic;

namespace BudgetPro.Server.Data;

public partial class Budget
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public long? CategoryId { get; set; }

    public float Amount { get; set; }

    public DateOnly? Timeframe { get; set; }

    public virtual Category? Category { get; set; }

    public virtual User User { get; set; } = null!;
}
