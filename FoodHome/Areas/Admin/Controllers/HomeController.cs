using Microsoft.AspNetCore.Mvc;

namespace FoodHome.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        
        public async Task<IActionResult> Index()
        {
            return View();
        }
      
    }
}
