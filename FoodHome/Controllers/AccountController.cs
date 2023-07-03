using FoodHome.Core.Contracts;
using FoodHome.Core.Models.Account;
using FoodHome.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodHome.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IUserService userService;
        private readonly IImageService imageService;
        private readonly ICustomerService customerService;
        public AccountController(UserManager<User> _userManager,SignInManager<User> _signInManager ,IUserService _userService, IImageService _imageService, ICustomerService _customerService)
        {
            this.userManager = _userManager;
            this.signInManager = _signInManager;
            this.userService = _userService;
            this.imageService = _imageService;
            this.customerService = _customerService;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            var model = new RegisterViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(await userService.ExistsByEmail(model.Email))
            {
                ModelState.AddModelError(nameof(model.Email), "There is already registered user with this email");
            }

            if(await userService.ExistsByPhone(model.PhoneNumber))
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
                UserName = model.Name,
                PhoneNumber = model.PhoneNumber,
                Country = model.Country,
                City = model.City,
                Address = model.Address

            };

            var result = await userManager.CreateAsync(user, model.Password);

            await userManager.AddToRoleAsync(user, "Customer");
            await customerService.Create(user.Id);

            user.ProfilePictureUrl = await imageService.UploadImage(model.ProfilePicture, "images", user);
            await userManager.UpdateAsync(user);

            if(result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);

                return RedirectToAction("Index", "Home");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model); 
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByEmailAsync(model.Email);

            if(user != null)
            {
                if (user.IsActive)
                {
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }
            }

            ModelState.AddModelError(nameof(model.Email), "Invalid login");

            return View(model);
        }
    }
}
