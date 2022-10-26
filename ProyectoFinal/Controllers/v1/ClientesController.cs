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
            return await dbContext.Cliente.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> Get(int id)
        { 
            var cliente = await dbContext.Cliente.FindAsync(id);

            if (cliente == null)
            {
                return NotFound("No se ha encontrado el cliente");
            }
            else {
                return cliente;
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Cliente cliente)
        {
            dbContext.Cliente.Add(cliente);

            await dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Cliente cliente)
        {
            if (id != cliente.ClienteId)
            {
                return BadRequest("No se ha encontrado el cliente");
            }

            dbContext.Entry(cliente).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        //     Borrar Cliente, no accesible

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    var cliente = await dbContext.Cliente.FindAsync(id);

        //    if (cliente == null) 
        //    {
        //        return NotFound("No se ha encontrado el cliente");
        //    }

        //    dbContext.Remove(cliente);
        //    await dbContext.SaveChangesAsync();

        //    return Ok();
        //}
    }
}
