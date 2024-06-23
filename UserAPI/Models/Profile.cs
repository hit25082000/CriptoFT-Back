namespace UserAPI.Models
{
    public class Profile : Entity
    {
        public User User { get; set; }
        public string Icon { get; set; }
        public List<Video> FavovireVideos { get; set; }
    }
}
