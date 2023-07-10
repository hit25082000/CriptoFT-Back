namespace UserAPI.Models
{
    public class Noticia : Entity
    {      
        public string titulo { get; set; }
        public string conteudo { get; set; }
        public DateTime data { get; set; }
        public int autor { get; set; }
        public User aspnetusersID { get; set; }       
    }
}
