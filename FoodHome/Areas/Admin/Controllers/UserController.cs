using FoodHome.Core.Contracts;
using FoodHome.Core.Models.Account;
using FoodHome.Core.Models.User;
using FoodHome.Core.Services;
using Microsoft.AspNetCore.Mvc;

using static FoodHome.Common.NotificationConstants;

namespace FoodHome.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService userService;
        private readonly IProfileService profileService;

        public UserController(IUserService _userService, IProfileService _profileService)
        {
            this.userService = _userService;
            this.profileService = _profileService;
        }

        public async Task<IActionResult> All()
        {
            var users = await userService.GetAllUsers();

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                var user = await userService.GetUserByIdAsync(id);

                var model = new EditProfileModel()
                {
                    Id = id,
                    Name = user.Name,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Country = user.Country,
                    City = user.City,
                    Address = user.Address,

                };

                return View(model);
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, EditProfileModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            try
            {
                await profileService.Edit(id, model);

                return RedirectToAction("All");
            }
            catch (Exception e)
            {
                TempData[ErrorMessage] = e.Message;

                return RedirectToAction("Index", "Home");

            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string userId)
        {
            if (!await userService.ExistsById(userId))
            {
                return RedirectToAction("All");
            }

            var userToDelete = await userService.GetUserByIdAsync(userId);
            return View(userToDelete);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(string userId, UserModel model)
        {
            if (!await userService.ExistsById(userId))
            {
                return RedirectToAction("All");
            }

            await userService.DeleteUser(userId);

            return RedirectToAction("All");
        }

    }
}
