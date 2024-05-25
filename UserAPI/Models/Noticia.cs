namespace UserAPI.Models
{
    public class Noticia : Entity
    {      
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public DateTime Data { get; set; }
    }
}
