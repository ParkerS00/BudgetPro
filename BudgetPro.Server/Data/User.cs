using System;
using System.Collections.Generic;

namespace BudgetPro.Server.Data;

public partial class User
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Budget> Budgets { get; set; } = new List<Budget>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
