using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Contexts;
using ProyectoFinal.Entities;

namespace ProyectoFinal.Controllers.v1
{
    [ApiController]
    [Route("api/v1/facturas")]
    public class FacturasController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public FacturasController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Factura>>> Get()
        {
            var facturas = dbContext.Factura
                .Include(x => x.Cliente);
            return await facturas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Factura>> Get(int id)
        {
            var factura = await dbContext.Factura.FindAsync(id);

            if (factura == null)
            {
                return NotFound("No se ha encontrado la factura");
            }
            else {
                return factura;
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Factura factura)
        {
            var cliente = await dbContext.Cliente.FindAsync(factura.ClienteId);

            if (cliente == null)
            {
                return NotFound("No se ha encontrado el cliente");
            }
            else
            {
                factura.Estado = Estado.Activa;
                dbContext.Factura.Add(factura);
                await dbContext.SaveChangesAsync();

                return Ok();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Factura factura)
        {
            if (id != factura.FacturaId)
            {
                return BadRequest("No se ha encontrado la factura");
            }

            dbContext.Entry(factura).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        //     Borrar Factura, no accesible

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    var factura = await dbContext.Factura.FindAsync(id);

        //    if (factura == null)
        //    {
        //        return NotFound("No se ha encontrado la factura");
        //    }

        //    //dbContext.Remove(factura);
        //    factura.Estado = Estado.Cancelada;
        //    await dbContext.SaveChangesAsync();

        //    return Ok();
        //}
    }
}
