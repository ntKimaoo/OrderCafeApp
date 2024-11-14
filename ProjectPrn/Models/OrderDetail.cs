using System;
using System.Collections.Generic;

namespace ProjectPrn.Models;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int SoLuong { get; set; }

    public decimal DonGia { get; set; }

    public decimal? ThanhTien { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
