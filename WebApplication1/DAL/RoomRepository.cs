using System.Data.Entity;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace WebApplication1.DAL
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelDatabaseContext _context;

        public RoomRepository(HotelDatabaseContext context)
        {
            _context = context;
        }

        public IQueryable<Phong> GetAllPhongs()
        {
            return _context.Phongs.AsQueryable();
        }

        public Phong GetPhongById(int MaPhong)
        {
            return _context.Phongs.Find(MaPhong);
        }

        public void InsertPhong(Phong phong)
        {
            _context.Phongs.Add(phong);
        }

        public void UpdatePhong(Phong phong)
        {
            //_context.Entry(phong).State = EntityState.Modified;
            var existingRoom = _context.Phongs.Find(phong.MaPhong);
            if (existingRoom != null)
            {
                existingRoom.TenPhong = phong.TenPhong;
                existingRoom.MaLoai = phong.MaLoai;

                _context.SaveChanges();
            }
        }

        public void DeletePhong(int MaPhong)
        {
            Phong phong = _context.Phongs.Find(MaPhong);
            if (phong != null)
            {
                _context.Phongs.Remove(phong);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
