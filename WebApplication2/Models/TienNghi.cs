using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class TienNghi
{
    public int MaTn { get; set; }

    public int MaLoai { get; set; }

    public string? Gia { get; set; }

    public string? Den { get; set; }

    public virtual ICollection<TienIchPhong> TienIchPhongs { get; set; } = new List<TienIchPhong>();
}
