namespace UserAPI.Models
{
    public class Entity
    {
        public int Id { get; set; }

        public Entity()
        {
            Id = new Random().Next();
        }
    }
}
