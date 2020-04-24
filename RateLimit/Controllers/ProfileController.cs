using Microsoft.AspNetCore.Mvc;
using RateLimit.Services;
using X.PagedList;

namespace RateLimit.Controllers
{
    public class ProfileController: Controller
    {
        public object Profiles(int? page, int? pageSize, string searchString)
        {
            var profiles = ProfileService.GetProfiles("FirstName", 1, searchString);

            IPagedList onePageOfProducts = profiles.ToPagedList(page ?? 1, pageSize ?? 2);
            ViewBag.OnePageOfProducts = onePageOfProducts;

            return View();
        }
    }
}
