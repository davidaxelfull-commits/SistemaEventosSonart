using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEventosSonart.Models
{
    public class SolicitudEvento
    {
        public int SolicitudEventoId { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [Required]
        public string TipoEvento { get; set; } = string.Empty;

        [Required]
        public DateTime FechaEvento { get; set; }

        [Required]
        public string EstadoSolicitud { get; set; } = string.Empty;

        [ForeignKey("ClienteId")]
        public Cliente? Cliente { get; set; }

        public ICollection<Cotizacion>? Cotizaciones { get; set; }
    }
}