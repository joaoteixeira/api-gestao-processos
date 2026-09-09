using ApiGestaoProcessos.Data;
using ApiGestaoProcessos.Dtos;
using ApiGestaoProcessos.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Filters;

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

        // POST: /processos - Cadastro de uum novo processo
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProcessoDto novoProcesso)
        {
            try
            {
                var processo = new Processo()
                {
                    Numero = novoProcesso.Numero,
                    Data = novoProcesso.Data,
                    Interessado = novoProcesso.Interessado,
                    Assunto = novoProcesso.Assunto,
                    Descricao = novoProcesso.Descricao
                };

                await _context.Processos.AddAsync(processo);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = processo.Id }, processo);

            } catch
            {
                return Problem("Ocorreram erros ao salvar o processo");
            }
        }


        // PUT: /processos/{id} - Atualiza um processo existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProcessoUpdateDto processoAtualizado)
        {
            try
            {
                var processoExistente = await _context.Processos.FirstOrDefaultAsync(x => x.Id == id);

                if (processoExistente is null)
                {
                    return NotFound(new { Mensagem = $"Processo informado não encontrado" });
                }

                processoExistente.Numero = processoAtualizado.Numero;
                processoExistente.Data = processoAtualizado.Data;
                processoExistente.Interessado = processoAtualizado.Interessado;
                processoExistente.Assunto = processoAtualizado.Assunto;
                processoExistente.Descricao = processoAtualizado.Descricao;

                //if (processoAtualizado.Situacao is not null)
                //{
                //    processoExistente.Situacao = processoAtualizado.Situacao;
                //}

                await _context.SaveChangesAsync();

                return NoContent();
            } catch
            {
                return Problem("Ocorreram erros ao atualizar o processo");
            }
        }

        // DELETE: /processos/{id} - Remove um processo
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var processoExistente = await _context.Processos.FirstOrDefaultAsync(x => x.Id == id);

            if (processoExistente is null)
            {
                return NotFound(new { Mensagem = $"Processo informado não encontrado" });
            }

            _context.Processos.Remove(processoExistente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("{id}/concluir")]
        public async Task<IActionResult> Concluir(int id)
        {
            try
            {
                var processoExistente = await _context.Processos.FirstOrDefaultAsync(x => x.Id == id);

                if (processoExistente is null)
                {
                    return NotFound(new { Mensagem = $"Processo informado não encontrado" });
                }

                //processoExistente.Situacao = "Concluído";

                await _context.SaveChangesAsync();

                return Ok(processoExistente);
            }
            catch
            {
                return Problem("Ocorreram erros ao finalizar o processo");
            }
        }
    }
}
