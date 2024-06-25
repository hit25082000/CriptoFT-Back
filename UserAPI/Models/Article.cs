namespace UserAPI.Models
{
    public class Article : Entity
    {      
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Theme { get; set; }
        public string Url { get; set; }
        public string ImgPath { get; set; }
    }
}
