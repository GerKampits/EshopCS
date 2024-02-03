using System;
using System.Collections.Generic;

namespace EShopApp.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? VatRegNo { get; set; }

    public string? PhoneNo { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
