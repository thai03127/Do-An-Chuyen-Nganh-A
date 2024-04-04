using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Phong
    {
        public Phong()
        {
            QldichvuPhongs = new HashSet<QldichvuPhong>();
        }

        public int MaPhong { get; set; }
        public string? TenPhong { get; set; }
        public int? MaLoai { get; set; }

        public virtual ICollection<QldichvuPhong> QldichvuPhongs { get; set; }
    }
}
