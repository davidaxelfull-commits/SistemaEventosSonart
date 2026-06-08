using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEventosSonart.Models
{
    public class PaqueteServicio
    {
        public int PaqueteServicioId { get; set; }

        [Required]
        public string NombrePaquete { get; set; } = string.Empty;

        [Required]
        public int CapacidadPersonas { get; set; }

        [Required]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecioBase { get; set; }

        public ICollection<Cotizacion>? Cotizaciones { get; set; }
    }
}