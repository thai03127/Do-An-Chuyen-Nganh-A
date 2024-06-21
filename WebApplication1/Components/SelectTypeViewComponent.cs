using Microsoft.AspNetCore.Mvc;
using WebApplication1.DAL;
using WebApplication1.OtherModels;

namespace WebApplication1.Components
{
    public class SelectTypeViewComponent : ViewComponent
    {
        private readonly ITypeRoomRepository _typeRoomRepository;
        public SelectTypeViewComponent(ITypeRoomRepository typeRoomRepository)
        {
            _typeRoomRepository = typeRoomRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loaiPhongList = _typeRoomRepository.GetAllLoaiPhongs(); // Lấy dữ liệu LoaiPhong từ repository
            return View(loaiPhongList);
        }
    }
}
