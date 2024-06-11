using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Dichvu
{
    public int MaDv { get; set; }

    public string? TenDv { get; set; }

    public int? SoLuong { get; set; }

    public virtual ICollection<QldichvuPhong> QldichvuPhongs { get; set; } = new List<QldichvuPhong>();
}
