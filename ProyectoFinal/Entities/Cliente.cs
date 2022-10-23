using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Entities
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required]
        [StringLength(50)]
        public string? Nombre { get; set; }

        [MinLength(8), MaxLength(8)]
        public string? Telefono { get; set; }

        [StringLength(60)]
        public string? Direccion { get; set; }
        

    }
}
