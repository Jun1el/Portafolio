using Portafolio.Models;
using Resend;

namespace Portafolio.Servicios
{
    public class ServicioEmailResend : IServicioEmail
    {
        private readonly IConfiguration _configuration;
        private readonly IResend _resend;
        private readonly ILogger<ServicioEmailResend> _logger;

        public ServicioEmailResend(IConfiguration configuration, IResend resend, ILogger<ServicioEmailResend> logger)
        {
            _configuration = configuration;
            _resend = resend;
            _logger = logger;
        }

        public async Task Enviar(ContactoViewModel contacto)
        {
            var from = _configuration.GetValue<string>("CONFIGURACIONES_EMAIL:FROM");
            var to = _configuration.GetValue<string>("CONFIGURACIONES_EMAIL:TO");

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

                await _resend.EmailSendAsync(message);
                _logger.LogInformation("Email enviado correctamente de {Email}", contacto.Email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al enviar email de {Email}", contacto.Email);
                throw;
            }
        }
    }
}
