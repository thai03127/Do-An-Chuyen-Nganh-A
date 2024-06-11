using Microsoft.AspNetCore.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Components
{
    public class RoomViewComponent : ViewComponent
    {
        private readonly IRoomRepository _roomRepository;
        public RoomViewComponent(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var phongs = await _roomRepository.GetAllPhongs().ToListAsync();
            return View(phongs);
        }
    }
}
