using Microsoft.AspNetCore.Identity;

namespace EcommerceApplication.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
