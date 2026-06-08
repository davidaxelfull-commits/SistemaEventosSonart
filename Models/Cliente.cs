using System.ComponentModel.DataAnnotations;

namespace SistemaEventosSonart.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Telefono { get; set; } = string.Empty;

        [Required]
        public string Correo { get; set; } = string.Empty;

        [Required]
        public string Direccion { get; set; } = string.Empty;

        public ICollection<SolicitudEvento>? SolicitudesEvento { get; set; }
    }
}