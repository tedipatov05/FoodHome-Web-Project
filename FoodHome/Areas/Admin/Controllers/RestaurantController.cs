using FoodHome.Areas.Admin.ViewModels;
using FoodHome.Core.Contracts;
using FoodHome.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodHome.Areas.Admin.Controllers
{
    public class RestaurantController : BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IUserService userService;
        private readonly IImageService imageService;
        private readonly IRestaurantService restaurantService;

        public RestaurantController(UserManager<User> _userManager, SignInManager<User> _signInManager, IUserService _userService, IImageService _imageService, IRestaurantService _restaurantService)
        {
            this.userManager = _userManager;
            this.signInManager = _signInManager;
            this.userService = _userService;
            this.imageService = _imageService;
            this.restaurantService = _restaurantService;
        }
        [HttpGet]
        public IActionResult Add()
        {
            var model = new AddRestaurantViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRestaurantViewModel model)
        {
            if (await userService.ExistsByEmail(model.Email))
            {
                ModelState.AddModelError(nameof(model.Email), "There is already registered user with this email");
            }

            if (await userService.ExistsByPhone(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "There is already registered user with this phone number");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User()
            {
                Name = model.Name,
                Email = model.Email,
                UserName = model.Name.Trim(),
                PhoneNumber = model.PhoneNumber,
                Country = model.Country,
                City = model.City,
                Address = model.Address

            };

            var result = await userManager.CreateAsync(user, model.Password);

            await userManager.AddToRoleAsync(user, "Restaurant");

            await restaurantService.Create(user.Id);

            user.ProfilePictureUrl = await imageService.UploadImage(model.ProfilePicture, "images", user);
            await userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(model);
        }
    }
}
