using Microsoft.AspNetCore.Mvc;
using RateLimit.Filters;
using RateLimit.Models;
using RateLimit.Services;
using X.PagedList;

namespace RateLimit.Controllers
{
    public class ProfileController: Controller
    {
        [RateLimit(Seconds = 1)]
        public IActionResult Profiles(int page = 1, int pageSize = 3, string searchString = "")
        {
            var profiles = ProfileService.GetProfiles("FirstName", searchString);

            IPagedList<ProfileViewModel> profilePagedList = profiles.ToPagedList(page, pageSize);
            
            return View(profilePagedList);
        }
    }
}
