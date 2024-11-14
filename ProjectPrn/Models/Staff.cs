using System;
using System.Collections.Generic;

namespace ProjectPrn.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string Ten { get; set; } = null!;

    public string? ChucVu { get; set; }

    public string? DienThoai { get; set; }

    public string? DiaChi { get; set; }
    public string? username {  get; set; }
    public string? password { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
