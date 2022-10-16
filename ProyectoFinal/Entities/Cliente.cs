using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Entities
{
    public class Cliente
    {

        [Key]
        public int ClienteId { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(8)]
        public int Telefono { get; set; }

        [StringLength(60)]
        public int Direccion { get; set; }


    }
}
