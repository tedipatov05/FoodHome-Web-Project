using Microsoft.AspNetCore.Mvc;

namespace FoodHome.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
      
    }
}
