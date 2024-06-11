using Microsoft.AspNetCore.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Components
{
    public class MenuServiceViewComponent : ViewComponent
    {
        private readonly IServiceRepository _serviceRepository;
        public MenuServiceViewComponent(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var services = await _serviceRepository.GetAllDichVus().ToListAsync();
            return View(services);
        }
    }
}
