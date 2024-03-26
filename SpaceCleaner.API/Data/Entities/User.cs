using Microsoft.AspNetCore.Identity;

namespace SpaceCleaner.API.Data.Entities
{
    public class User : IdentityUser
    {
        public int Points { get; set; }
    }
}
