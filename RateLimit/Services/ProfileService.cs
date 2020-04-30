using RateLimit.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace RateLimit.Services
{
    public class ProfileService
    {
        public IEnumerable<ProfileViewModel> GetProfiles(string searchString)
        {
            var profiles = ReadProfiles();

            if (!string.IsNullOrEmpty(searchString))
            {
                profiles = profiles.Where(s => s.LastName.Contains(searchString) || s.FirstName.Contains(searchString));
            }

            return profiles;
        }

        private IEnumerable<ProfileViewModel> ReadProfiles()
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
