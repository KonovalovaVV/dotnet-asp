using Microsoft.AspNetCore.Mvc;
using RateLimit.Services;

namespace RateLimit.Controllers
{
    public class ProfileController: Controller
    {
        public IActionResult Profiles()
        {
            return View(ProfileService.GetProfiles("Birthday", 1,null));
        }
    }
}
