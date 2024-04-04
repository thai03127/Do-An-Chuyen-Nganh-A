using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class TienIchPhong
    {
        public int MaLoai { get; set; }
        public int MaTn { get; set; }
        public int? SoLuong { get; set; }

        public virtual LoaiPhong MaLoaiNavigation { get; set; } = null!;
        public virtual TienNghi MaTnNavigation { get; set; } = null!;
    }
}
