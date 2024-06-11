using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public interface IRoomRepository 
    {
        IQueryable<Phong> GetAllPhongs();
        Phong GetPhongById(int MaPhong);
        void InsertPhong(Phong phong);
        void UpdatePhong(Phong phong);
        void DeletePhong(int MaPhong);
        void Save();
    }
}
