using Microsoft.AspNetCore.Mvc.Filters;

namespace RateLimit.Filters
{
    public class RateLimitAttribute : ActionFilterAttribute 
    {
        public int Seconds { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }
    }
}
