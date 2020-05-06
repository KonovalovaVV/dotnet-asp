using RateLimit.Filters;
using RateLimit.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using X.PagedList;

namespace RateLimit.Services
{
    public class ProfileService
    {
        private static IEnumerable<ProfileViewModel> profiles;

        static ProfileService()
        {
            ReadProfiles();
        }

        public IPagedList<ProfileViewModel> GetProfiles(ProfileFilter filter)
        {
            var profileViewModels = profiles;

            if (!string.IsNullOrEmpty(filter.SearchString))
            {
                profileViewModels = profileViewModels
                    .Where(s => s.LastName.Contains(filter.SearchString) || s.FirstName.Contains(filter.SearchString));
            }

            SortProfiles(ref profileViewModels, filter.SortOrder);

            return profileViewModels.ToPagedList(filter.PageNumber, filter.PageCount);
        }

        private static void ReadProfiles()
        {
            using (StreamReader r = new StreamReader("profiles.json"))
            {
                string json = r.ReadToEnd();
                profiles = JsonSerializer.Deserialize<List<ProfileViewModel>>(json);
            }
        }

        private static void SortProfiles(ref IEnumerable<ProfileViewModel> profileViewModels, SortState sortOrder)
        {
            profileViewModels = sortOrder switch
            {
                SortState.LastNameDesc => profileViewModels.OrderByDescending(s => s.LastName),
                SortState.BirthdayAsc => profileViewModels.OrderBy(s => s.Birthday),
                SortState.FirstNameDesc => profileViewModels.OrderByDescending(s => s.FirstName),
                SortState.FirstNameAsc => profileViewModels.OrderBy(s => s.FirstName),
                SortState.BirthdayDesc => profileViewModels.OrderByDescending(s => s.Birthday),
                _ => profileViewModels.OrderBy(s => s.LastName),
            };
        }
    }
}
