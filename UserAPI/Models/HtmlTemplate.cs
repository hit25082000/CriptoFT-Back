namespace UserAPI.Models
{
    public class HtmlTemplate : Entity
    {
        public HtmlTemplate()
        {
            Carrossel = new Noticia[3];
        }

        public Noticia Home { get; set; }
        public Noticia[] Carrossel { get; set; }
        public List<Aula> Videos { get; set; }
    }
}
