using ApiGestaoProcessos.Data;
using ApiGestaoProcessos.Dtos;
using ApiGestaoProcessos.Entities;
using ApiGestaoProcessos.Services;
using AutoMapper;
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

        private readonly ProcessoService _service;

        public ProcessoController(AppDbContext context, ProcessoService service)
        {
            _context = context;
            _service = service;
        }

        // GET: /processos - Lista todos os processos
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var processos = await _service.FindAll();

                return Ok(processos);
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
                var processo = await _service.FindById(id);

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
                var processo = await _service.Create(novoProcesso);

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
                await _service.Update(id, processoAtualizado);

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

                processoExistente.Situacao = "Concluído";

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
