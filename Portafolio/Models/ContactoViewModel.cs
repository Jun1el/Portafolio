using System.ComponentModel.DataAnnotations;

namespace Portafolio.Models
{
    public class ContactoViewModel
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        [RegularExpression(@"^\d{9}$", ErrorMessage = "El teléfono debe tener 9 dígitos.")]
        public int Numero { get; set; }
        public string Mensaje { get; set; }

    }
}
