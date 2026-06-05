using Portafolio.Models;
using System.Net;
using System.Net.Mail;

namespace Portafolio.Servicios
{
    public interface IServicioEmail
    {
        Task Enviar(ContactoViewModel contacto);
    }

    public class ServicioEmailGmail : IServicioEmail
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<ServicioEmailGmail> logger;

        public ServicioEmailGmail(IConfiguration configuration, ILogger<ServicioEmailGmail> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }
        public async Task Enviar(ContactoViewModel contacto)
        {
            var emailEmisor = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:EMAIL");
            var password = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:PASSWORD");
            var host = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:HOST");
            var puerto = configuration.GetValue<int>("CONFIGURACIONES_EMAIL:PUERTO");

            try
            {
                using var smtpClient = new SmtpClient(host, puerto);
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(emailEmisor, password);
                smtpClient.Timeout = 30000;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                var message = new MailMessage(
                    emailEmisor!,
                    emailEmisor!,
                    $"Nuevo mensaje de {contacto.Nombre} ({contacto.Email}) quiere contactarte",
                    contacto.Mensaje);

                await smtpClient.SendMailAsync(message);
                logger.LogInformation("Email enviado correctamente de {Email}", contacto.Email);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al enviar email de {Email}", contacto.Email);
                throw;
            }
        }
    }
}
