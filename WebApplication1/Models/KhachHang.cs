﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class KhachHang
    {
        public int MaKh { get; set; }
        public string TenKh { get; set; } = null!;
        public int Passport { get; set; }
        public int Cancuoc { get; set; }
        public int? Phone { get; set; }
    }
}
