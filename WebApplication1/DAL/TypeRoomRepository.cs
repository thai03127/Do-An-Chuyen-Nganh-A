using System.Data.Entity;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace WebApplication1.DAL
{
    public class TypeRoomRepository : ITypeRoomRepository
    {
        private readonly HotelDatabaseContext _context  ;

        public TypeRoomRepository(HotelDatabaseContext context)
        {
            _context = context;
        }

        public IQueryable<LoaiPhong> GetAllLoaiPhongs()
        {
            return _context.LoaiPhongs.AsQueryable();
        }

        public LoaiPhong GetLoaiPhongById(int MaLoai)
        {
            return _context.LoaiPhongs.Find(MaLoai);
        }

        public void InsertLoaiPhong(LoaiPhong loaiPhong)
        {
            _context.LoaiPhongs.Add(loaiPhong);
        }

        public void UpdateLoaiPhong(LoaiPhong loaiPhong)
        {
            _context.Entry(loaiPhong).State = EntityState.Modified;
        }

        public void DeleteLoaiPhong(int MaLoai)
        {
            LoaiPhong loaiPhong = _context.LoaiPhongs.Find(MaLoai);
            if (loaiPhong != null)
            {
                _context.LoaiPhongs.Remove(loaiPhong);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        //LoaiPhong ITypeRoomRepository.GetLoaiPhongById(int MaLoai)
        //{
        //    throw new NotImplementedException();
        //}



        //public IEnumerable<Phong> GetAllPhongs()
        //{
        //    throw new NotImplementedException();
        //}

        //public Phong GetPhongById(int MaPhong)
        //{
        //    throw new NotImplementedException();
        //}

        //public void InsertPhong(Phong phong)
        //{
        //    throw new NotImplementedException();
        //}

        //public void UpdatePhong(Phong phong)
        //{
        //    throw new NotImplementedException();
        //}

        //public void DeletePhong(int MaPhong)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
