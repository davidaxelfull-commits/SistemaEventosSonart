using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEventosSonart.Models
{
    public class ServicioAdicional
    {
        public int ServicioAdicionalId { get; set; }

        [Required]
        public string NombreServicio { get; set; } = string.Empty;

        [Required]
        public string Categoria { get; set; } = string.Empty;

        [Required]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecioReferencial { get; set; }
    }
}