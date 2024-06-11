using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Phong
{
    public int MaPhong { get; set; }

    public string? TenPhong { get; set; }

    public int? MaLoai { get; set; }

    public virtual ICollection<Checkin> Checkins { get; set; } = new List<Checkin>();

    public virtual LoaiPhong? MaLoaiNavigation { get; set; }

    public virtual ICollection<QldichvuPhong> QldichvuPhongs { get; set; } = new List<QldichvuPhong>();
}
