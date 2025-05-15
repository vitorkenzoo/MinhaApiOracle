using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaApiOracle.Data;
using MinhaApiOracle.Models;

namespace MinhaApiOracle.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly AppDb _context;

        public ClientesController(AppDb context)
        {
            _context = context;
        }

        // GET api/clientes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _context.Clientes.Include(c => c.Endereco).ToListAsync();
            return Ok(clientes);
        }

        // GET api/clientes/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _context.Clientes.Include(c => c.Endereco).FirstOrDefaultAsync(c => c.IdClientes == id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        // GET api/clientes/buscar?nome=...
        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarPorNome([FromQuery] string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return BadRequest("O parâmetro 'nome' é obrigatório.");

            var clientes = await _context.Clientes
                .Include(c => c.Endereco)
                .Where(c => c.Nome.Contains(nome))
                .ToListAsync();

            if (clientes.Count == 0) return NotFound();

            return Ok(clientes);
        }

        // POST api/clientes
        [HttpPost]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = cliente.IdClientes }, cliente);
        }

        // PUT api/clientes/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Cliente cliente)
        {
            if (id != cliente.IdClientes) return BadRequest();

            var existingCliente = await _context.Clientes.FindAsync(id);
            if (existingCliente == null) return NotFound();

            // Atualiza campos explicitamente para evitar problemas de tracking
            existingCliente.Nome = cliente.Nome;
            existingCliente.Cpf = cliente.Cpf;
            existingCliente.Telefone = cliente.Telefone;
            existingCliente.EnderecoId = cliente.EnderecoId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/clientes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return NotFound();

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
