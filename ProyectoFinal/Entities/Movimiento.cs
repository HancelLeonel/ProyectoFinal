using System.ComponentModel.DataAnnotations;
using System.Xml.Schema;

namespace ProyectoFinal.Entities
{
    public class Movimiento
    {
        [Key]
        public int MovimientoId { get; set; }

        public string? Fecha { get; set; }

        public float? TotalPago { get; set; }


        // Relaciones
        public int FacturaId { get; set; }
        public Factura? Factura { get; set; }

    }
}
