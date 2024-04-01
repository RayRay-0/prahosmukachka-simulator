using Microsoft.AspNetCore.Identity;

namespace SpaceCleaner.API.Data.Entities
{
    public class User : IdentityUser
    {
        public int Shards { get; set; }

        public int? LevelId { get; set; }
        public virtual Level? Level { get; set; }

        public virtual Skin? Skin { get; set; }
        public int? SkinId { get; set; }
    }
}
