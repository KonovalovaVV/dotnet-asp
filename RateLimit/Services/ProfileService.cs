using PagedList;
using RateLimit.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace RateLimit.Services
{
    public class ProfileService
    {
        public static IPagedList<ProfileViewModel> GetProfiles(string sortField, int? page, string searchString)
        {
            List<ProfileViewModel> profiles;
            using (StreamReader r = new StreamReader("profiles.json"))
            {
                string json = r.ReadToEnd();
                profiles = JsonSerializer.Deserialize<List<ProfileViewModel>>(json);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                profiles = profiles.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString)).ToList();
            }

            switch (sortField)
            {
                case "Birthday":
                    profiles = profiles.OrderBy(s => s.Birthday).ToList();
                    break;
                case "LastName":
                    profiles = profiles.OrderBy(s => s.LastName).ToList();
                    break;
                case "FirstName":
                    profiles = profiles.OrderBy(s => s.FirstName).ToList();
                    break;
                default:
                    profiles = profiles.OrderBy(s => s.Id).ToList();
                    break;
            }

            int pageSize = 1;
            int pageNumber = (page ?? 1);
            return profiles.ToPagedList(pageNumber, pageSize);
        }
    }
}
