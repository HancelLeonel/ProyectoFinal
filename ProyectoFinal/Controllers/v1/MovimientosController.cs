using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Contexts;
using ProyectoFinal.Entities;

namespace ProyectoFinal.Controllers.v1
{
    [ApiController]
    [Route("api/v1/movimientos")]
    public class MovimientosController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public MovimientosController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movimiento>>> Get()
        {
            var movimientos = dbContext.Movimiento.
                Include(x => x.Factura.Cliente);
            return await movimientos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movimiento>> Get(int id)
        {
            var movimiento = await dbContext.Movimiento.FindAsync(id);

            if (movimiento == null)
            {
                return NotFound("No se ha encontrado el registro");
            }
            else
            {
                return movimiento;
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Movimiento movimiento)
        {
            var factura = await dbContext.Factura.FindAsync(movimiento.FacturaId);
            if (factura == null)
            {
                return NotFound("No se ha encontrado la factura");
            }
            else
            {
                if (factura.Estado == Estado.Cancelada)
                {
                    return BadRequest("Esa factura ya ha sido cancelada");
                }
                else
                {
                    if (movimiento.TotalPago != factura.Total)
                    {
                        var monto = factura.Total;

                        return BadRequest("Debe pagar el monto total de la factura: " + monto);
                    }
                    else
                    {
                        factura.Estado = Estado.Cancelada;
                        dbContext.Movimiento.Add(movimiento);

                        await dbContext.SaveChangesAsync();
                        return Ok();
                    }
                }
            }
        }

        //     Actualizar movimiento, no accesible

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(int id, Movimiento movimiento) {
        //    if (id != movimiento.MovimientoId) {
        //        return BadRequest();
        //    }

        //    dbContext.Entry(movimiento).State = EntityState.Modified;
        //    await dbContext.SaveChangesAsync();
        //    return Ok();
        //}


        //     Borrar movimiento, no accesible

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    var movimiento = await dbContext.Movimiento.FindAsync(id);

        //    if (movimiento == null)
        //    {
        //        return NotFound();
        //    }
        //    dbContext.Remove(movimiento);
        //    await dbContext.SaveChangesAsync();

        //    return Ok();
        //}
    }
}
