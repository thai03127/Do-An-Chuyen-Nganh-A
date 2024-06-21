using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Diagnostics;
using WebApplication1.DAL;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.OtherModels;
namespace WebApplication1.Controllers
{
    public class ServiceController : Controller
    {
        //private readonly ILogger<ServiceController> _logger;
        //private readonly HotelDatabaseContext _dbContext; // những thuộc tính private sẽ gạch dưới

        //public ServiceController(ILogger<ServiceController> logger, HotelDatabaseContext context)
        //{
        //    _logger = logger;
        //    _dbContext = context;
        //}
        //public IActionResult Service()
        //{
        //    var services = _dbContext.Dichvus.ToList();
        //    return View(services);
        //}

    
        //repository 
        //SERVICE
        private readonly IServiceRepository _serviceRepository;
        private readonly ITypeRoomRepository _typeRoomRepository;
        private readonly IImageRepository _imageRepository;

        DetailRoom details;
        DetailService detailService;


        public ServiceController(IServiceRepository serviceRepository, ITypeRoomRepository typeRoomRepository, IImageRepository imageRepository)
        {
            _serviceRepository = serviceRepository;
            _typeRoomRepository = typeRoomRepository;
            _imageRepository = imageRepository;
        }

        public IActionResult DetailRoom(int id)
        {
            var type = _typeRoomRepository.GetLoaiPhongById(id);
            var serviceNames = _serviceRepository.GetAllDichVuNames();
            var image = _imageRepository.GetHinhAnhsByMaLoai(id);
            string[] img = new string[4];
            var index = 0;
            foreach (var i in image)
            {
                img[index] = i.Hinh;
                index++; 
            }
            details = new DetailRoom { info = type, service = serviceNames, image = img };
            return View(details);
        }

        public IActionResult DetailService(int id)
        {
            var service = _serviceRepository.GetDichVuById(id);
            detailService  = new DetailService { info = service };
            return View(detailService);
            //var service = _serviceRepository.GetDichVuById(id);
            //if (service == null)
            //{
            //    // Handle the case where the service is not found
            //    return NotFound();
            //}

            //ViewBag.serviceName = service.TenDv;
            //ViewBag.serviceQuantity = service.SoLuong;
            //ViewBag.serviceDescription = service.Mota;

            //var rooms = _roomRepository.GetAllPhongs();
            //if (rooms == null)
            //{
            //    // Handle the case where rooms list is not found or is null
            //    return NotFound();
            //}

            //var filteredRooms = from p in rooms
            //                    where p.MaLoai == id
            //                    select p;

            //return View(filteredRooms.ToList());
        }

        // GETALL: /Services/
        public IActionResult Service()
        {
            var dichVus = _serviceRepository.GetAllDichVus();
            //var dichVus = from s in _serviceRepository.GetAllDichVus()
            //               select s;
            return View(dichVus);
        }

        // SEARCH: /FindService/
        public IActionResult FindService(int MaDv)
        {
            var dichVu = _serviceRepository.GetDichVuById(MaDv);
            if (dichVu == null)
            {
                return NotFound();
            }
            return View(dichVu);
        }

        // POST: /AddService/
        public IActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("MaDv,TenDv,SoLuong, Mota")] Dichvu dichVu)
        {
            if (ModelState.IsValid)
            {
                _serviceRepository.InsertDichVu(dichVu);
                _serviceRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(dichVu);
        }


        // PUT: /UpdateService/
        public IActionResult EditService(int MaDv)
        {
            var dichVu = _serviceRepository.GetDichVuById(MaDv);
            if (dichVu == null)
            {
                return NotFound();
            }
            return View(dichVu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int MaDv, [Bind("TenDv,SoLuong, Mota")] Dichvu dichVu)
        {
            if (MaDv != dichVu.MaDv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _serviceRepository.UpdateDichVu(dichVu);
                    _serviceRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_serviceRepository.GetAllDichVus().Any(e => e.MaDv == MaDv))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dichVu);
        }


        // DELETE: /DeleteService/
        public IActionResult DeleteService(int MaDv)
        {
            var dichVu = _serviceRepository.GetDichVuById(MaDv);
            if (dichVu == null)
            {
                return NotFound();
            }
            return View(dichVu);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmedService(int MaDv)
        {
            _serviceRepository.DeleteDichVu(MaDv);
            _serviceRepository.Save();
            return RedirectToAction(nameof(Index));
        }


        /// <summary>
        /// //////////
        /// </summary>
        //ROOM
        // GETALL: /Rooms/
        public IActionResult Room()
        {
            var loaiPhongs = from s in _typeRoomRepository.GetAllLoaiPhongs()
                             select s;
            return View(loaiPhongs);
        }

        // SEARCH: /FindRoom/
        public IActionResult FindRoom(int MaLoai)
        {
            var loaiPhong = _typeRoomRepository.GetLoaiPhongById(MaLoai);
            if (loaiPhong == null)
            {
                return NotFound();
            }
            return View(loaiPhong);
        }

        // POST: /AddRoom/
        public IActionResult CreateRoom()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("MaLoai,Ten, Gia, GiaGoc, GiaGiam, DanhGia, Soluong, GiaTreEm, Mota")] LoaiPhong loaiPhong)
        {
            if (ModelState.IsValid)
            {
                _typeRoomRepository.InsertLoaiPhong(loaiPhong);
                _typeRoomRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiPhong);
        }


        // PUT: /UpdateRoom/
        public IActionResult EditRoom(int MaLoai)
        {
            var loaiPhong = _typeRoomRepository.GetLoaiPhongById(MaLoai);
            if (loaiPhong == null)
            {
                return NotFound();
            }
            return View(loaiPhong);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int MaLoai, [Bind("Ten, Gia, GiaGoc, GiaGiam, DanhGia, Soluong, GiaTreEm,Mota")] LoaiPhong loaiPhong)
        {
            if (MaLoai != loaiPhong.MaLoai)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _typeRoomRepository.UpdateLoaiPhong(loaiPhong);
                    _typeRoomRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_typeRoomRepository.GetAllLoaiPhongs().Any(e => e.MaLoai == MaLoai))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(loaiPhong);
        }


        // DELETE: /DeleteRoom/
        public IActionResult DeleteRoom(int MaLoai)
        {
            var loaiPhong = _typeRoomRepository.GetLoaiPhongById(MaLoai);
            if (loaiPhong == null)
            {
                return NotFound();
            }
            return View(loaiPhong);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmedRoom(int MaLoai)
        {
            _typeRoomRepository.DeleteLoaiPhong(MaLoai);
            _typeRoomRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}

