using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public interface IServiceRepository
    {
        IQueryable<Dichvu> GetAllDichVus();
        Dichvu GetDichVuById(int MaDv);
        void InsertDichVu(Dichvu MaDv);
        void UpdateDichVu(Dichvu dichvu);
        void DeleteDichVu(int MaDv);
        void Save();
        IEnumerable<string> GetAllDichVuNames();
    }
}
