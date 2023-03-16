using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class EmailService
    {
        private IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(string[] destiny, string about, int userId, string code)
        {
            Mensage mensage = new Mensage(destiny, about, userId, code);
            var emailMensage = CreateEmailBody(mensage);
            Send(emailMensage);
        }

        private void Send(MimeMessage emailMensage)
        {
            using (var client = new SmtpClient())
            {
                try{
                    client.Connect("smtp-mail.outlook.com", 587, SecureSocketOptions.StartTls);
                    client.AuthenticationMechanisms.Remove("XOUATH2");
                    client.Authenticate(_configuration.GetValue<string>("EmailSettings:From"),
                        _configuration.GetValue<string>("EmailSettings:Password"));
                    client.Send(emailMensage);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private MimeMessage CreateEmailBody(Mensage mensage)
        {
            var emailMensage = new MimeMessage();
            emailMensage.From.Add(MailboxAddress.Parse(_configuration.GetValue<string>("EmailSettings:From")));
            emailMensage.To.AddRange(mensage.Destiny);
            emailMensage.Subject = mensage.About;

            var htmlBody = new BodyBuilder();
            htmlBody.HtmlBody = $"<p>Olá, Obrigado por se cadastrar no CryptoFT.</p>"
                             + "<p>Para ativar a sua conta, clique no botão abaixo:</p>"
                             + $"<p><a href='{mensage.Content}' style='background-color: #4CAF50; color: white; padding: 12px 20px; text-align: center; text-decoration: none; display: inline-block; border-radius: 4px;'>Ativar Conta</a></p>"
                             + "<p>Se o botão não funcionar, você também pode ativar a sua conta copiando e colando o seguinte link em seu navegador:</p>"
                             + $"<p><a href='{mensage.Content}'>{mensage.Content}</a></p>";

            emailMensage.Body = htmlBody.ToMessageBody();
            
            return emailMensage;
        }
    }
}
