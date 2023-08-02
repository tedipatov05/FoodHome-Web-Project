using FoodHome.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FoodHome.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            this.userService = _userService;
            
        }
        
        public async Task<IActionResult> All()
        {
            var users = await userService.GetAllUsers();

            return View(users);
        }
    }
}
