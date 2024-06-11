using Microsoft.AspNetCore.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Components
{
    public class TypeRoomViewComponent : ViewComponent
    {
        private readonly ITypeRoomRepository _typeRoomRepository;
        public TypeRoomViewComponent(ITypeRoomRepository typeRoomRepository)
        {
            _typeRoomRepository = typeRoomRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loaiPhongs = await _typeRoomRepository.GetAllLoaiPhongs().ToListAsync();
            return View(loaiPhongs);
        }
    }
}
