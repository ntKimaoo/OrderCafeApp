using System;
using System.Collections.Generic;

namespace ProjectPrn.Models;

public partial class Ban
{
    public int BanId { get; set; }

    public string SoBan { get; set; } = null!;

    public string TrangThai { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
