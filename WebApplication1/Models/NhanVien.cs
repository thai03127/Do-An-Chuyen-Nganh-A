using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            Bookings = new HashSet<Booking>();
        }

        public int MaNv { get; set; }
        public string? TenNv { get; set; }
        public string Chucvu { get; set; } = null!;
        public int Cancuoc { get; set; }
        public int Phone { get; set; }
        public int TrangThai { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
