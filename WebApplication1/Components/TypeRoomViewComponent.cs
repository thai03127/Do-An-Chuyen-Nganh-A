using Microsoft.AspNetCore.Mvc;
using WebApplication1.DAL;

using Microsoft.EntityFrameworkCore;
using WebApplication1.OtherModels;


namespace WebApplication1.Components
{
    public class TypeRoomViewComponent : ViewComponent
    {
        private readonly ITypeRoomRepository _typeRoomRepository;
        private readonly IImageRepository _imageRepository;


        List<DetailType> details = new List<DetailType>();
        public TypeRoomViewComponent(ITypeRoomRepository typeRoomRepository, IImageRepository imageRepository)
        {
            _typeRoomRepository = typeRoomRepository;
            _imageRepository = imageRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loaiPhongs = await _typeRoomRepository.GetAllLoaiPhongs().ToListAsync();
            foreach(var type in loaiPhongs)
            {
                var hinh = _imageRepository.GetHinhAnhsByMaLoai(type.MaLoai);
                int id = 0;
                int[] array = new int[hinh.Count()];

                foreach (var item in hinh)
                {
                    array[id] = item.MaHinhAnh;
                    id++;
                }
                
                Random rand = new Random();
                id = array[rand.Next(0,hinh.Count()-1)];

                var info = (_imageRepository.GetHinhAnhById(id));
                details.Add(new DetailType { info = type, hinh = info.Hinh });
            }
      
            return View(details);
        }
    }
}
