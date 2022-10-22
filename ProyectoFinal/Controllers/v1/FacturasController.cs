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
        public async Task<ActionResult<List<Factura>>> Get(int id)
        {
            var factura = dbContext.Factura
                .Include(x => x.Cliente)
                .Where(s => s.FacturaId == id);

            if (factura == null)
            {
                return NotFound();
            }
            else {
                return await factura.ToListAsync();
            }
        }


        [HttpPost]
        public async Task<ActionResult> Post(Factura factura)
        {
            dbContext.Factura.Add(factura);

            await dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Factura factura)
        {
            if (id != factura.FacturaId)
            {
                return BadRequest();
            }

            dbContext.Entry(factura).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var factura = await dbContext.Factura.FindAsync(id);

            if (factura == null)
            {
                return NotFound();
            }

            dbContext.Remove(factura);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
