using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public interface ITypeRoomRepository
    {
            IQueryable<LoaiPhong> GetAllLoaiPhongs();
            LoaiPhong GetLoaiPhongById(int MaLoai);
            void InsertLoaiPhong(LoaiPhong loaiphong);
            void UpdateLoaiPhong(LoaiPhong loaiphong);
            void DeleteLoaiPhong(int MaLoai);
            void Save();

    }
}
