using Microsoft.AspNetCore.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Components
{
    public class ListStaffViewComponent : ViewComponent
    {
        private readonly IStaffRepository _listStaffRepository;
        public ListStaffViewComponent(IStaffRepository listStaffRepository)
        {
            _listStaffRepository = listStaffRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listStaffs = await _listStaffRepository.GetAllStaffs().ToListAsync();
            return View(listStaffs);
        }
    }
}
