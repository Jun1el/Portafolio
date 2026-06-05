using Portafolio.Models;
using Resend;

namespace Portafolio.Servicios
{
    public interface IServicioEmail
    {
        Task Enviar(ContactoViewModel contacto);
    }

    public class ServicioEmailGmail : IServicioEmail
    {
        private readonly IConfiguration configuration;
        private readonly IResend resend;
        private readonly ILogger<ServicioEmailGmail> logger;

        public ServicioEmailGmail(IConfiguration configuration, IResend resend, ILogger<ServicioEmailGmail> logger)
        {
            this.configuration = configuration;
            this.resend = resend;
            this.logger = logger;
        }

        public async Task Enviar(ContactoViewModel contacto)
        {
            var from = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:FROM");
            var to = configuration.GetValue<string>("CONFIGURACIONES_EMAIL:TO");

            try
            {
                var message = new EmailMessage();
                message.From = from!;
                message.To.Add(to!);
                message.Subject = $"Nuevo mensaje de {contacto.Nombre} ({contacto.Email}) - Tel: {contacto.Numero}";
                message.HtmlBody = $"<p><strong>Nombre:</strong> {contacto.Nombre}</p>" +
                                   $"<p><strong>Email:</strong> {contacto.Email}</p>" +
                                   $"<p><strong>Teléfono:</strong> {contacto.Numero}</p>" +
                                   $"<p><strong>Mensaje:</strong></p><p>{contacto.Mensaje}</p>";

                await resend.EmailSendAsync(message);
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
