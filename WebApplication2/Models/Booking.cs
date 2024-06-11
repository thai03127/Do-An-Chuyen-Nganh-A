using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Booking
{
    public int MaBooking { get; set; }

    public int MaKh { get; set; }

    public int MaLoai { get; set; }

    public string NgayIn { get; set; } = null!;

    public string NgayOut { get; set; } = null!;

    public string Gia { get; set; } = null!;

    public string GiaGoc { get; set; } = null!;

    public string GiaGiam { get; set; } = null!;

    public int MaNv { get; set; }

    public string TrangThai { get; set; } = null!;

    public string DatCoc { get; set; } = null!;

    public virtual ICollection<Checkin> Checkins { get; set; } = new List<Checkin>();

    public virtual KhachHang MaKhNavigation { get; set; } = null!;

    public virtual LoaiPhong MaLoaiNavigation { get; set; } = null!;

    public virtual NhanVien MaNvNavigation { get; set; } = null!;
}
