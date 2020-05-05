using RateLimit.Models;

namespace RateLimit.Filters
{
    public class ProfileFilter
    {
        public int PageNumber = 1;
        public int PageCount = 3;
        public string SearchString;
        public SortState SortOrder;
    }
}
