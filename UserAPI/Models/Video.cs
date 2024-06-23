namespace UserAPI.Models
{
    public class Video : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public DateTime Date { get; set; }
        public int CourseId { get; set; }
    }
}
