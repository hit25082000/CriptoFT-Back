namespace UserAPI.Models
{
    public class Article : Entity
    {      
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
