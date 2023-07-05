using FoodHome.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FoodHome.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly IProfileService profileService;
        private readonly IRestaurantService restaurantService;

        public ProfileController(IProfileService _profileService, IRestaurantService _restaurantService)
        {
            profileService = _profileService;
            restaurantService = _restaurantService;
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
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
