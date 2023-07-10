namespace UserAPI.Models
{
    public class Aula : Entity
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string VideoUrl { get; set; }
        public int Autor { get; set; }
        public DateTime Data { get; set; }
        public User User { get; set; }
    }
}
