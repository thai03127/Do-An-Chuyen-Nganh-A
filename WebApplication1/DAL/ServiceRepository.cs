using System.Data.Entity;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace WebApplication1.DAL
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly HotelDatabaseContext _context;
        public ServiceRepository(HotelDatabaseContext context)
        {
            _context = context;
        }
        public IQueryable<Dichvu> GetAllDichVus()
        {
            return _context.Dichvus.AsQueryable();
        }

        public Dichvu GetDichVuById(int MaDv)
        {
            return _context.Dichvus.Find(MaDv);
        }

        public void InsertDichVu(Dichvu dichvu)
        {
            _context.Dichvus.Add(dichvu);
        }

        public void UpdateDichVu(Dichvu dichvu)
        {
            _context.Entry(dichvu).State = EntityState.Modified;
        }

        public void DeleteDichVu(int MaDv)
        {
            Dichvu dichvu = _context.Dichvus.Find(MaDv);
            if (dichvu != null)
            {
                _context.Dichvus.Remove(dichvu);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }


        IEnumerable<string> IServiceRepository.GetAllDichVuNames()
        {
            return _context.Dichvus.Select(s => s.TenDv).ToList();
        }

        //Dichvu IServiceRepository.GetDichVuById(int MaDv) => throw new NotImplementedException();
    }
}
