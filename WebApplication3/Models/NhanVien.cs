using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            Bookings = new HashSet<Booking>();
        }

        public int MaNv { get; set; }
        public string TenNv { get; set; } = null!;
        public string Chucvu { get; set; } = null!;
        public int Cancuoc { get; set; }
        public int Phone { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
