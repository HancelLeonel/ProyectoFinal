using Microsoft.AspNetCore.Http;
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

    }
}
