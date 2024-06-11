using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public interface IStaffRepository 
    {
        IQueryable<NhanVien> GetAllStaffs();
        NhanVien GetStaffById(int MaNv);
        void InsertStaff(NhanVien nhanVien);
        void UpdateStaff(NhanVien nhanVien);
        void DeleteStaff(int MaNv);
        void Save();
    }
}
