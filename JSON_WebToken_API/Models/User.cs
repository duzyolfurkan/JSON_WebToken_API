using Microsoft.AspNetCore.Identity;

namespace JSON_WebToken_API.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
