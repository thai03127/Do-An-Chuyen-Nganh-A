using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class QldichvuPhong
    {
        public int Id { get; set; }
        public int? MaPhong { get; set; }
        public int? MaDv { get; set; }
        public string? Sotien { get; set; }
        public string? Soluong { get; set; }

        public virtual DichVu? MaDvNavigation { get; set; }
        public virtual Phong? MaPhongNavigation { get; set; }
    }
}
