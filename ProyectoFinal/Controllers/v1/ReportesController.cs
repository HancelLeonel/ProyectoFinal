using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Contexts;
using ProyectoFinal.Entities;

namespace ProyectoFinal.Controllers.v1
{
    [ApiController]
    [Route("api/v1/reportes")]
    public class ReportesController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public ReportesController(AppDbContext dbContext)
        { 
            this.dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Factura>>> Get(int id)
        {
            var cliente = await dbContext.Cliente.FindAsync(id);

            if (cliente == null)
            {
                return NotFound("No se ha encontrado el cliente");
            }
            else
            {
                var datos = dbContext.Factura
                    .Include(c => c.Cliente)
                    .Where(f => f.ClienteId == id);
                return await datos.ToListAsync();
            }
        }
    }
}
