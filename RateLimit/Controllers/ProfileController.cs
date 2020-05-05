using Microsoft.AspNetCore.Mvc;
using RateLimit.Filters;
using RateLimit.Models;
using RateLimit.Services;

namespace RateLimit.Controllers
{
    public class ProfileController: Controller
    {
        private ProfileService profileService;

        public ProfileController(ProfileService profileService)
        {
            this.profileService = profileService;
        }

        [RateLimit(Seconds = 1)]
        public IActionResult Profiles(string searchString = "", SortState sortOrder = SortState.LastNameAsc, int page = 1, int pageCount = 3)
        {
            ProfileFilter profileFilter = new ProfileFilter
            {
                SearchString = searchString,
                SortOrder = sortOrder,
                PageNumber = page,
                PageCount = pageCount
            };

            return View(profileService.GetProfiles(profileFilter));
        }
    }
}
