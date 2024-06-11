﻿using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public partial class TienNghi
    {
        public TienNghi()
        {
            TienIchPhongs = new HashSet<TienIchPhong>();
        }

        public int MaTn { get; set; }
        public int MaLoai { get; set; }
        public string? Gia { get; set; }
        public string? Den { get; set; }

        public virtual ICollection<TienIchPhong> TienIchPhongs { get; set; }
    }
}
