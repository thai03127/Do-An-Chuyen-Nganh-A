using System.Data.Entity;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace WebApplication1.DAL
{
    public class StaffRepository : IStaffRepository
    {
        private readonly HotelDatabaseContext _context;

        public StaffRepository(HotelDatabaseContext context)
        {
            _context = context;
        }

        public IQueryable<NhanVien> GetAllStaffs()
        {
            return _context.NhanViens.AsQueryable();
        }

        public NhanVien GetStaffById(int MaNv)
        {
            return _context.NhanViens.Find(MaNv);
        }

        public void InsertStaff(NhanVien nhanVien)
        {
            _context.NhanViens.Add(nhanVien);
        }


        public void UpdateStaff(NhanVien nhanVien)
        {
            //_context.Entry(nhanVien).State = EntityState.Modified;
            var existingStaff = _context.NhanViens.Find(nhanVien.MaNv);
            if (existingStaff != null)
            {
                existingStaff.TenNv = nhanVien.TenNv;
                existingStaff.Chucvu = nhanVien.Chucvu;
                existingStaff.Cancuoc = nhanVien.Cancuoc;
                existingStaff.Phone = nhanVien.Phone;
                existingStaff.TrangThai = nhanVien.TrangThai;

                _context.SaveChanges();
            }
        }

        public void DeleteStaff(int MaNv)
        {
            NhanVien nhanVien = _context.NhanViens.Find(MaNv);
            if (nhanVien != null)
            {
                _context.NhanViens.Remove(nhanVien);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
