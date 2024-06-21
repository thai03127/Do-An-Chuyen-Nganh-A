using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class BookingDetail
    {
        public int MaBooking { get; set; }
        public int Id { get; set; }
        public int? MaLoai { get; set; }
        public int? SoLuong { get; set; }
        public double? Gia { get; set; }
        public double? GiaGoc { get; set; }
        public double? GiaGiam { get; set; }

        public virtual Booking MaBookingNavigation { get; set; } = null!;
        public virtual LoaiPhong? MaLoaiNavigation { get; set; }
    }
}
