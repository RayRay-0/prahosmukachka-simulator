using Microsoft.AspNetCore.Identity;

namespace SpaceCleaner.API.Data.Entities
{
    public class Level : BaseEntity
    {
        public string Name { get; set; }
        public int EasterEggNumber { get; set; }
        public virtual ICollection<User>? Users { get; set; }
    }
}
