using WebApplication1.Models;

namespace WebApplication1.OtherModels
{
    public class DetailRoom
    {
        public LoaiPhong info { get; set; }
        public IEnumerable<string> service { get; set; }
        public string[] image { get; set; }
    }
}
