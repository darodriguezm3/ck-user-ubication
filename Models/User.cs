using System.ComponentModel.DataAnnotations;

namespace UserRegistrationApi.Models
{
    public class User
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [Phone(ErrorMessage = "El formato del teléfono no es válido.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria.")]
        [StringLength(250, ErrorMessage = "La dirección no puede tener más de 250 caracteres.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "El municipio es obligatorio.")]
        public int TownId { get; set; }
    }
}
