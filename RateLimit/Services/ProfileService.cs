using RateLimit.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace RateLimit.Services
{
    public class ProfileService
    {
        public static IEnumerable<ProfileViewModel> GetProfiles(string sortField, string searchString)
        {
            var profiles = ReadProfiles();

            if (!string.IsNullOrEmpty(searchString))
            {
                profiles = profiles.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }

            profiles = sortField switch
            {
                "Birthday" => profiles.OrderBy(s => s.Birthday),
                "LastName" => profiles.OrderBy(s => s.LastName),
                "FirstName" => profiles.OrderBy(s => s.FirstName),
                _ => profiles.OrderBy(s => s.Id).ToList(),
            };

            return profiles;
        }

        private static IEnumerable<ProfileViewModel> ReadProfiles()
        {
            IEnumerable<ProfileViewModel> profiles;
            using (StreamReader r = new StreamReader("profiles.json"))
            {
                string json = r.ReadToEnd();
                profiles = JsonSerializer.Deserialize<List<ProfileViewModel>>(json);
            }

            return profiles;
        }
    }
}
