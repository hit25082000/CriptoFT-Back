namespace UserAPI.Models
{
    public class Profile : Entity
    {
        public User User { get; set; }
        public string Icone { get; set; }
        public List<Aula> AulasAssistidas { get; set; }
        public string Sobre { get; set; }
    }
}
