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

            var formatProfileViewModel = new FormatProfileViewModel
            {
                ProfileFilter = profileFilter,
                Profiles = profileService.GetProfiles(profileFilter)
            };

            return View(formatProfileViewModel);
        }
    }
}
