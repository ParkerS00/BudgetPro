using System;
using System.Collections.Generic;

namespace BudgetPro.Server.Data;

/// <summary>
/// Categories for expenses/income
/// </summary>
public partial class Category
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsIncome { get; set; }

    public long UserId { get; set; }

    public virtual ICollection<Budget> Budgets { get; set; } = new List<Budget>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual User User { get; set; } = null!;
}
