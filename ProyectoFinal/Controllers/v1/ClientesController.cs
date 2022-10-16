using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Contexts;
using ProyectoFinal.Entities;

namespace ProyectoFinal.Controllers.v1
{

    [ApiController]
    [Route("v1/clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext dbContext;


        public ClientesController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            return dbContext.Cliente.ToList();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Cliente cliente)
        {
            dbContext.Cliente.Add(cliente);

            await dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var estudiante = await dbContext.Cliente.FindAsync(id);

            if (estudiante == null) 
            {
                return NotFound();
            }

            dbContext.Remove(estudiante);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }

    }
}
