using Microsoft.AspNetCore.Mvc;
using RateLimit.Filters;
using RateLimit.Services;
using X.PagedList;

namespace RateLimit.Controllers
{
    public class ProfileController: Controller
    {

        [RateLimit(Seconds = 5)]
        public IActionResult Profiles(int page = 1, int pageSize = 3, string searchString = "")
        {
            var profiles = ProfileService.GetProfiles("FirstName", searchString);

            IPagedList onePageOfProducts = profiles.ToPagedList(page, pageSize);
            ViewBag.OnePageOfProducts = onePageOfProducts;

            return View();
        }
    }
}
