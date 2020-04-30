using Microsoft.AspNetCore.Mvc;
using RateLimit.Filters;
using RateLimit.Models;
using RateLimit.Services;
using System.Linq;
using X.PagedList;

namespace RateLimit.Controllers
{
    public class ProfileController: Controller
    {
        private ProfileService profileService;

        public ProfileController(ProfileService profileService)
        {
            this.profileService = profileService;
        }

        [RateLimit(Seconds = 2)]
        public IActionResult Profiles(int page = 1, int pageSize = 3, string searchString = "", SortState sortOrder = SortState.LastNameAsc)
        {
            var profiles = profileService.GetProfiles(searchString);

            ViewData["LastNameSort"] = sortOrder == SortState.LastNameAsc ? SortState.LastNameDesc : SortState.LastNameAsc;
            ViewData["FirstNameSort"] = sortOrder == SortState.FirstNameAsc ? SortState.FirstNameDesc : SortState.FirstNameAsc;
            ViewData["BirthdaySort"] = sortOrder == SortState.BirthdayAsc ? SortState.BirthdayDesc : SortState.BirthdayAsc;

            profiles = sortOrder switch
            {
                SortState.LastNameDesc => profiles.OrderByDescending(s => s.LastName),
                SortState.BirthdayAsc => profiles.OrderBy(s => s.Birthday),
                SortState.FirstNameDesc => profiles.OrderByDescending(s => s.FirstName),
                SortState.FirstNameAsc => profiles.OrderBy(s => s.FirstName),
                SortState.BirthdayDesc => profiles.OrderByDescending(s => s.Birthday),
                _ => profiles.OrderBy(s => s.LastName),
            };

            IPagedList<ProfileViewModel> profilePagedList = profiles.ToPagedList(page, pageSize);
            
            return View(profilePagedList);
        }
    }
}
