using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Checkin
    {
        public int MaBooking { get; set; }
        public string TimeIn { get; set; } = null!;
        public int MaPhong { get; set; }
        public string NvPv { get; set; } = null!;
        public string TrangThai { get; set; } = null!;
        public int MaNv { get; set; }
        public int Id { get; set; }

        public virtual Booking MaBookingNavigation { get; set; } = null!;
        public virtual Phong MaPhongNavigation { get; set; } = null!;
    }
}
