using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class NhanVien
{
    public int MaNv { get; set; }

    public string TenNv { get; set; } = null!;

    public string Chucvu { get; set; } = null!;

    public int Cancuoc { get; set; }

    public int Phone { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
