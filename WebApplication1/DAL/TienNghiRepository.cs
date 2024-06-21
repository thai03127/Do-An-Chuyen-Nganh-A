using System.Data.Entity;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace WebApplication1.DAL
{
    public class TienNghiRepository : ITienNghiRepository
    {
        private readonly HotelDatabaseContext _context;

        public TienNghiRepository(HotelDatabaseContext context)
        {
            _context = context;
        }
        public IQueryable<TienNghi> GetAllTienNghis()
        {
            return _context.TienNghis.AsQueryable();
        }

        public TienNghi GetTienNghiById(int MaTN)
        {
            return _context.TienNghis.Find(MaTN);
        }

        public void InsertTienNghi(TienNghi tienNghi)
        {
            _context.TienNghis.Add(tienNghi);
        }

        public void UpdateTienNghi(TienNghi tienNghi)
        {
            //_context.Entry(tienNghi).State = EntityState.Modified;
            var existingTienNghi = _context.TienNghis.Find(tienNghi.MaTn);
            if (existingTienNghi != null)
            {
                existingTienNghi.Ten = tienNghi.Ten;
                existingTienNghi.MaLoai = tienNghi.MaLoai;
                existingTienNghi.Gia = tienNghi.Gia;
                existingTienNghi.Den = tienNghi.Den;

                _context.SaveChanges();
            }
        }

        public void DeleteTienNghi(int MaTN)
        {
            TienNghi tienNghi = _context.TienNghis.Find(MaTN);
            if (tienNghi != null)
            {
                _context.TienNghis.Remove(tienNghi);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
