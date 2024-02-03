using System;
using System.Collections.Generic;

namespace EShopApp.Models;

public partial class Order
{
    public int Id { get; set; }

    public decimal? Amount { get; set; }

    public string? Description { get; set; }

    public int? Status { get; set; }

    public DateTime? Date { get; set; }

    public int? CustomerId { get; set; }

    public virtual Customer? Customer { get; set; }
}
