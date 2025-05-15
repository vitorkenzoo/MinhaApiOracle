using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaApiOracle.Data;
using MinhaApiOracle.Models;

namespace MinhaApiOracle.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VagasController : ControllerBase
    {
        private readonly AppDb _context;

        public VagasController(AppDb context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vagas = await _context.Vagas.ToListAsync();
            return Ok(vagas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vaga = await _context.Vagas.FindAsync(id);
            if (vaga == null) return NotFound();
            return Ok(vaga);
        }

        // Rota extra: GET api/vagas/buscar?ocupado=valor
        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarPorOcupado([FromQuery] string ocupado)
        {
            if (string.IsNullOrWhiteSpace(ocupado))
                return BadRequest("O parâmetro 'ocupado' é obrigatório.");

            var vagas = await _context.Vagas
                .Where(v => v.Ocupado.Contains(ocupado))
                .ToListAsync();

            if (vagas.Count == 0) return NotFound();

            return Ok(vagas);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Vaga vaga)
        {
            _context.Vagas.Add(vaga);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = vaga.Id }, vaga);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Vaga vaga)
        {
            if (id != vaga.Id) return BadRequest();

            var existingVaga = await _context.Vagas.FindAsync(id);
            if (existingVaga == null) return NotFound();

            existingVaga.Numero = vaga.Numero;
            existingVaga.Ocupado = vaga.Ocupado;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vaga = await _context.Vagas.FindAsync(id);
            if (vaga == null) return NotFound();

            _context.Vagas.Remove(vaga);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
