using System;
using System.Collections.Generic;

namespace ProjectPrn.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? BanId { get; set; }

    public int StaffId { get; set; }

    public DateTime NgayLap { get; set; }

    public decimal TongTien { get; set; }

    public string TrangThai { get; set; } = null!;

    public virtual Ban? Ban { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Staff Staff { get; set; } = null!;
}
