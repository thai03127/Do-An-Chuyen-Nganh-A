using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;


namespace WebApplication1.DAL
{
    public class ImageRepository : IImageRepository
    {
        private readonly HotelDatabaseContext _context;

        public ImageRepository(HotelDatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<HinhAnh> GetHinhAnhsByMaLoai(int maLoai)
        {
            return _context.HinhAnhs
                           .Where(h => h.MaLoai == maLoai)
                           .ToList();
        }


        public IQueryable<HinhAnh> GetAllHinhAnhs()
        {
            return _context.HinhAnhs.AsQueryable();
        }

        public HinhAnh GetHinhAnhById(int MaHinhAnh)
        {
            return _context.HinhAnhs.Find(MaHinhAnh);
        }

        public void InsertHinhAnh(HinhAnh hinhanh)
        {
            _context.HinhAnhs.Add(hinhanh);
        }

        public void UpdateHinhAnh(HinhAnh hinhanh)
        {
            //_context.Entry(hinhanh).State = EntityState.Modified;
            var existingImage = _context.HinhAnhs.Find(hinhanh.MaHinhAnh);
            if (existingImage != null)
            {
                existingImage.Hinh = hinhanh.Hinh;
                existingImage.MaLoai = hinhanh.MaLoai;

                _context.SaveChanges();
            }
        }

        public void DeleteHinhAnh(int MaHinhAnh)
        {
            HinhAnh hinhAnh = _context.HinhAnhs.Find(MaHinhAnh);
            if (hinhAnh != null)
            {
                _context.HinhAnhs.Remove(hinhAnh);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
