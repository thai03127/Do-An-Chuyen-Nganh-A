using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class NhanVien
    {
        public int MaNv { get; set; }
        public string? TenNv { get; set; }
        public string? Chucvu { get; set; }
        public int Cancuoc { get; set; }
        public int? Phone { get; set; }
    }
}
