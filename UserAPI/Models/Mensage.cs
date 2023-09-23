using MimeKit;

namespace UserAPI.Models
{
    public class Mensage
    {
        public List<MailboxAddress> Destiny { get; set; } 
        public string About { get; set; }
        public string Content { get; set; }
        public Mensage(IEnumerable<string> destiny,string about, int userId,string code)
        {
            Destiny = new List<MailboxAddress>();
            Destiny.AddRange(destiny.Select(d => MailboxAddress.Parse(d)));
            About = about;
            Content = $"https://localhost:7084/ativa?UserId={userId}&ActivationCode={code}";
        }

        public Mensage(IEnumerable<string> destiny, string about, string code)
        {
            Destiny = new List<MailboxAddress>();
            Destiny.AddRange(destiny.Select(d => MailboxAddress.Parse(d)));
            About = about; 
            Content = $"http://localhost:4200/home/reset-senha?token={code}";
        }
    }
}
