using ApiGestaoProcessos.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGestaoProcessos.Controllers
{
    [Route("processos")]
    [ApiController]
    public class ProcessoController : ControllerBase
    {

        private readonly AppDbContext _context;

        public ProcessoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /processos - Lista todos os processos
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listaProcessos = await _context.Processos.ToListAsync();

                return Ok(listaProcessos);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // GET: /processos/{id} - Busca um processo por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var processo = await _context.Processos.FirstOrDefaultAsync(x => x.Id == id);

                if (processo is null)
                {
                    return NotFound(new { Mensagem = $"Processo {id} não encontrado" });
                }

                return Ok(processo);
            }
            catch
            {
                return Problem("Ocorreram erros ao buscar o processo");
            }
            
        }

        //// POST: /processos - Cadastro de uum novo processo
        //[HttpPost]
        //public IActionResult Post([FromBody] Processo novoProcesso)
        //{
        //    Processo.Lista.Add(novoProcesso);

        //    return CreatedAtAction(nameof(GetById), new { id = novoProcesso.Id }, novoProcesso);
        //}

        //// PUT: /processos/{id} - Atualiza um processo existente
        //[HttpPut("{id}")]
        //public IActionResult Put(Guid id, [FromBody] Processo processoAtualizado)
        //{
        //    var processoExistente = Processo.Lista.FirstOrDefault(x => x.Id == id);

        //    if (processoExistente is null)
        //    {
        //        return NotFound(new { Mensagem = $"Processo informado não encontrado" });
        //    }

        //    processoExistente.Nome = processoAtualizado.Nome;
        //    processoExistente.Status = processoAtualizado.Status;

        //    return NoContent();
        //}

        //// DELETE: /processos/{id} - Remove um processo
        //[HttpDelete("{id}")]
        //public IActionResult Delete(Guid id)
        //{
        //    var processoExistente = Processo.Lista.FirstOrDefault(x => x.Id == id);

        //    if (processoExistente is null)
        //    {
        //        return NotFound(new { Mensagem = $"Processo informado não encontrado" });
        //    }

        //    Processo.Lista.Remove(processoExistente);

        //    return NoContent();
        //}
    }
}
