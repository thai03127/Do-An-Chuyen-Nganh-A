using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class LoaiPhong
    {
        public LoaiPhong()
        {
            BookingDetails = new HashSet<BookingDetail>();
            HinhAnhs = new HashSet<HinhAnh>();
            Phongs = new HashSet<Phong>();
            TienIchPhongs = new HashSet<TienIchPhong>();
        }

        public int MaLoai { get; set; }
        public string? Ten { get; set; }
        public string? Gia { get; set; }
        public double? GiaGoc { get; set; }
        public double? GiaGiam { get; set; }
        public double? DanhGia { get; set; }
        public string? Soluong { get; set; }
        public double? GiaTreEm { get; set; }
        public string? Mota { get; set; }

        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
        public virtual ICollection<HinhAnh> HinhAnhs { get; set; }
        public virtual ICollection<Phong> Phongs { get; set; }
        public virtual ICollection<TienIchPhong> TienIchPhongs { get; set; }
    }
}
