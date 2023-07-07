using FoodHome.Core.Contracts;
using FoodHome.Core.Models.Account;
using Microsoft.AspNetCore.Mvc;

using static FoodHome.Common.NotificationConstants;

namespace FoodHome.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly IProfileService profileService;
        private readonly IRestaurantService restaurantService;
        private readonly IUserService userService;

        public ProfileController(IProfileService _profileService, IRestaurantService _restaurantService, IUserService _userService)
        {
            profileService = _profileService;
            restaurantService = _restaurantService;
            userService = _userService;
        }
        public async Task<IActionResult> MyProfile()
        {
            try
            {
                bool isRestaurant = await restaurantService.ExistsById(GetUserId());
                var myProfile = await profileService.MyProfile(GetUserId(), isRestaurant);

                myProfile.IsRestaurant = isRestaurant;

                
                return View("Profile", myProfile);

            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
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
            catch(Exception ex)
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

                return RedirectToAction("MyProfile");
            }
            catch (Exception e)
            {
                TempData[ErrorMessage] = e.Message;

                return RedirectToAction("Index", "Home");

            }
        }
        
    }
}
