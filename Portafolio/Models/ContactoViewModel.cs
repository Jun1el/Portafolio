using System.ComponentModel.DataAnnotations;

namespace Portafolio.Models
{
    public class ContactoViewModel
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        [RegularExpression(@"^\d{9,12}$", ErrorMessage = "El teléfono debe tener entre 9 y 12 dígitos.")]
        public string Numero { get; set; }
        public string Mensaje { get; set; }

    }
}
