using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEventosSonart.Models
{
    public class Cotizacion
    {
        public int CotizacionId { get; set; }

        [Required]
        public int SolicitudEventoId { get; set; }

        [Required]
        public int PaqueteServicioId { get; set; }

        [Required]
        public DateTime FechaCotizacion { get; set; }

        [Required]
        public string EstadoCotizacion { get; set; } = string.Empty;

        [ForeignKey("SolicitudEventoId")]
        public SolicitudEvento? SolicitudEvento { get; set; }

        [ForeignKey("PaqueteServicioId")]
        public PaqueteServicio? PaqueteServicio { get; set; }
    }
}