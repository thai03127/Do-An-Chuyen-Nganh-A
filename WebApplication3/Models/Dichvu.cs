using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class Dichvu
    {
        public Dichvu()
        {
            QldichvuPhongs = new HashSet<QldichvuPhong>();
        }

        public int MaDv { get; set; }
        public string? TenDv { get; set; }
        public int? SoLuong { get; set; }

        public virtual ICollection<QldichvuPhong> QldichvuPhongs { get; set; }
    }
}
