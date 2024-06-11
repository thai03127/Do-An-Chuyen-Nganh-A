using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class LoaiPhong
{
    public int MaLoai { get; set; }

    public string? Ten { get; set; }

    public string? Gia { get; set; }

    public double? GiaGoc { get; set; }

    public double? GiaGiam { get; set; }

    public double? DanhGia { get; set; }

    public string? Soluong { get; set; }

    public double? GiaTreEm { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<HinhAnh> HinhAnhs { get; set; } = new List<HinhAnh>();

    public virtual ICollection<Phong> Phongs { get; set; } = new List<Phong>();

    public virtual ICollection<TienIchPhong> TienIchPhongs { get; set; } = new List<TienIchPhong>();
}
