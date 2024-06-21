using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Booking
    {
        public Booking()
        {
            BookingDetails = new HashSet<BookingDetail>();
            Checkins = new HashSet<Checkin>();
        }

        public int MaBooking { get; set; }
        public int MaKh { get; set; }
        public string NgayIn { get; set; } = null!;
        public string NgayOut { get; set; } = null!;
        public int MaNv { get; set; }
        public string TrangThai { get; set; } = null!;
        public string DatCoc { get; set; } = null!;
        public int? SlKh { get; set; }

        public virtual KhachHang MaKhNavigation { get; set; } = null!;
        public virtual NhanVien MaNvNavigation { get; set; } = null!;
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
        public virtual ICollection<Checkin> Checkins { get; set; }
    }
}
