using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Contexts;
using ProyectoFinal.Entities;

namespace ProyectoFinal.Controllers.v1
{

    [ApiController]
    [Route("api/v1/clientes")]
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

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> Get(int id)
        { 
            var cliente = await dbContext.Cliente.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }
            else { }

            return cliente;
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
            var cliente = await dbContext.Cliente.FindAsync(id);

            if (cliente == null) 
            {
                return NotFound();
            }

            dbContext.Remove(cliente);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }

    }
}
