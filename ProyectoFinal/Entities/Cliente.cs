using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Entities
{
    public class Cliente
    {

        [Key]
        public int ClienteId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public int? Telefono { get; set; }

        [StringLength(60)]
        public string Direccion { get; set; }


    }
}
