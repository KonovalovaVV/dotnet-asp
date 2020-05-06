using System;

namespace RateLimit.Models
{
    public class ProfileViewModel
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime Birthday { get; set; }
    }
}
