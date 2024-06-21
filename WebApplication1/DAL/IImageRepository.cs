using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public interface IImageRepository
    {
        IQueryable<HinhAnh> GetAllHinhAnhs();
        HinhAnh GetHinhAnhById(int MaHinhAnh);
        IEnumerable<HinhAnh> GetHinhAnhsByMaLoai(int MaLoai);
        void InsertHinhAnh(HinhAnh hinhanh);
        void UpdateHinhAnh(HinhAnh hinhanh);
        void DeleteHinhAnh(int MaHinhAnh);
        void Save();
    }
}
