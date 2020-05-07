using Microsoft.AspNetCore.Identity;

namespace DanceStudio.Models
{
    public class UserEntity : IdentityUser
    {
        public UserEntity()
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}