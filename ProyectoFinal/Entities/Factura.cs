using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Entities
{
    public enum Estado
    {
        Activa,
        Cancelada
    }

    public class Factura
    {
        [Key]
        public int FacturaId { get; set; }

        //public int Estado { get; set; }
        public Estado? Estado { get; set; }

        [StringLength(50)]
        public string? Descripcion { get; set; }

        [StringLength(20)]
        public string? Fecha { get; set; }

        [StringLength(20)]
        public string? Vencimiento { get; set; }

        public float? Total { get; set; }


        // Relaciones
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
