using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Contexts;
using ProyectoFinal.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoFinal.Controllers.v1
{
    [Route("api/v1/facturas")]
    [ApiController]
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
            return dbContext.Factura.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Factura>> Get(int id)
        {
            var factura = await dbContext.Factura.FindAsync(id);

            if (factura == null)
            {
                return NotFound();
            }
            else {
                return factura;
            }

            
        }


        [HttpPost]
        public async Task<ActionResult> Post(Factura factura)
        {
            dbContext.Factura.Add(factura);

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
