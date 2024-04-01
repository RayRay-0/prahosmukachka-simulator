namespace SpaceCleaner.API.Data.Entities
{
    public class Skin : BaseEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public virtual ICollection<User>? Users { get; set; }
    }
}
