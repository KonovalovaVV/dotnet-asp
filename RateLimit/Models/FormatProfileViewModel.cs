using RateLimit.Filters;
using X.PagedList;

namespace RateLimit.Models
{
    public class FormatProfileViewModel
    {
        public ProfileFilter ProfileFilter;
        public IPagedList<ProfileViewModel> Profiles;
    }
}
