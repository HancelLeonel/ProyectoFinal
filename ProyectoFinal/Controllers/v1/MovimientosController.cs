using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Contexts;
using ProyectoFinal.Entities;
using Microsoft.VisualStudio.Web.CodeGeneration;

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

        // GET: api/Movimientos
        [HttpGet]
        public async Task<ActionResult<List<Movimiento>>> Get()
        {
            var movimientos = dbContext.Movimiento.
                Include(x => x.Factura.Cliente);
            return await movimientos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Movimiento movimiento)
        {
            dbContext.Movimiento.Add(movimiento);
            await dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Movimiento movimiento) {
            if (id != movimiento.MovimientoId) {
                return BadRequest();
            }

            dbContext.Entry(movimiento).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var movimiento = await dbContext.Movimiento.FindAsync(id);

            if (movimiento == null)
            {
                return NotFound();
            }

            dbContext.Remove(movimiento);
            await dbContext.SaveChangesAsync();

            return Ok();
        }

        // GET: api/Movimientos/5
       
    }
}
