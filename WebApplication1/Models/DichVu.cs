﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Models
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
        public string? Mota { get; set; }

        public virtual ICollection<QldichvuPhong> QldichvuPhongs { get; set; }
    }
}
