using Microsoft.AspNetCore.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Components
{
    public class StaffViewComponent : ViewComponent
    {
        private readonly IStaffRepository _staffRepository;
        public StaffViewComponent(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var staffs = await _staffRepository.GetAllStaffs().ToListAsync();
            return View(staffs);
        }
    }
}
