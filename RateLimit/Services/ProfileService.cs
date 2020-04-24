using RateLimit.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace RateLimit.Services
{
    public class ProfileService
    {
        public static IQueryable<ProfileViewModel> GetProfiles(string sortField, int? page, string searchString)
        {
            var profiles = ReadProfiles();

            if (!string.IsNullOrEmpty(searchString))
            {
                profiles = profiles.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString)).ToList();
            }

            profiles = sortField switch
            {
                "Birthday" => profiles.OrderBy(s => s.Birthday).ToList(),
                "LastName" => profiles.OrderBy(s => s.LastName).ToList(),
                "FirstName" => profiles.OrderBy(s => s.FirstName).ToList(),
                _ => profiles.OrderBy(s => s.Id).ToList(),
            };

            return profiles.AsQueryable();
        }

        private static List<ProfileViewModel> ReadProfiles()
        {
            List<ProfileViewModel> profiles;
            using (StreamReader r = new StreamReader("profiles.json"))
            {
                string json = r.ReadToEnd();
                profiles = JsonSerializer.Deserialize<List<ProfileViewModel>>(json);
            }

            return profiles;
        }
    }
}
