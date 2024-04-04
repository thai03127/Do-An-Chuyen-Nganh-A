using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Checkin
    {
        public int? MaBooking { get; set; }
        public string? TimeIn { get; set; }
        public int? MaPhong { get; set; }
        public string? NvPv { get; set; }
        public string? TrangThai { get; set; }
        public int? MaNv { get; set; }

        public virtual Booking? MaBookingNavigation { get; set; }
        public virtual Phong? MaPhongNavigation { get; set; }
    }
}
