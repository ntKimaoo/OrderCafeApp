using System;
using System.Collections.Generic;

namespace ProjectPrn.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string TenProduct { get; set; } = null!;

    public decimal Gia { get; set; }

    public string? MoTa { get; set; }

    public string? HinhAnh { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
