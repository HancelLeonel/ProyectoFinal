using System.ComponentModel.DataAnnotations;
using System.Xml.Schema;

namespace ProyectoFinal.Entities
{
    public class Movimiento
    {

        [Key]
        public int MovimientoId { get; set; }

        public String? Fecha { get; set; }

        public float? TotalPago { get; set; }

        public int FacturaId { get; set; }
        public Factura? Factura { get; set; }

    }
}
