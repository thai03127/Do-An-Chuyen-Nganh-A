using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class HinhAnh
{
    public int MaHinhAnh { get; set; }

    public int? MaLoai { get; set; }

    public virtual LoaiPhong? MaLoaiNavigation { get; set; }
}
