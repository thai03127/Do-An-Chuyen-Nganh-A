using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public interface ITienNghiRepository
    {
        IQueryable<TienNghi> GetAllTienNghis();
        TienNghi GetTienNghiById(int MaTN);
        void InsertTienNghi(TienNghi tienNghi);
        void UpdateTienNghi(TienNghi tienNghi);
        void DeleteTienNghi(int MaTN);
        void Save();
    }
}
