using Microsoft.AspNetCore.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Components
{
    public class BackGroundBookingViewComponent : ViewComponent
    {
        private readonly ITypeRoomRepository _bgBookingRepository;
        public BackGroundBookingViewComponent(ITypeRoomRepository bgBookingRepository)
        {
            _bgBookingRepository = bgBookingRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var bgBookings = await _bgBookingRepository.GetAllLoaiPhongs().ToListAsync();
            return View(bgBookings);
        }
    }
}
