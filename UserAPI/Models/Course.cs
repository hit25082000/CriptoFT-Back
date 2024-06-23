namespace UserAPI.Models
{
    public class Course : Entity
    {
        public string Thumb { get; set; }
        public string Description { get; set; }
        public int DurationMin { get; set; }
        public List<Video> Videos { get; set; }
    }
}
