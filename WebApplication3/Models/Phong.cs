using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Phong
    {
        public Phong()
        {
            Checkins = new HashSet<Checkin>();
            QldichvuPhongs = new HashSet<QldichvuPhong>();
        }

        public int MaPhong { get; set; }
        public string? TenPhong { get; set; }
        public int? MaLoai { get; set; }

        public virtual LoaiPhong? MaLoaiNavigation { get; set; }
        public virtual ICollection<Checkin> Checkins { get; set; }
        public virtual ICollection<QldichvuPhong> QldichvuPhongs { get; set; }
    }
}
