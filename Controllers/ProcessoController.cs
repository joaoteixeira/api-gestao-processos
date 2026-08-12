using ApiGestaoProcessos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestaoProcessos.Controllers
{
    [Route("processos")]
    [ApiController]
    public class ProcessoController : ControllerBase
    {

        // GET: /processos - Lista todos os processos
        [HttpGet]
        public IActionResult Get()
        {
            var listaProcessos = Processo.Lista;

            return Ok(listaProcessos);
        }

        // GET: /processos/{id} - Busca um processo por ID
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var processo = Processo.Lista.FirstOrDefault(x => x.Id == id);

            if (processo is null)
            {
                return NotFound(new { Mensagem = $"Processo {id} não encontrado" });
            }

            return Ok(processo);
        }

        // POST: /processos - Cadastro de uum novo processo
        [HttpPost]
        public IActionResult Post([FromBody] Processo novoProcesso)
        {
            Processo.Lista.Add(novoProcesso);

            return CreatedAtAction(nameof(GetById), new { id = novoProcesso.Id }, novoProcesso);
        }

        // PUT: /processos/{id} - Atualiza um processo existente
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Processo processoAtualizado)
        {
            var processoExistente = Processo.Lista.FirstOrDefault(x => x.Id == id);

            if (processoExistente is null)
            {
                return NotFound(new { Mensagem = $"Processo informado não encontrado" });
            }

            processoExistente.Nome = processoAtualizado.Nome;
            processoExistente.Status = processoAtualizado.Status;

            return NoContent();
        }

        // DELETE: /processos/{id} - Remove um processo
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var processoExistente = Processo.Lista.FirstOrDefault(x => x.Id == id);

            if (processoExistente is null)
            {
                return NotFound(new { Mensagem = $"Processo informado não encontrado" });
            }

            Processo.Lista.Remove(processoExistente);

            return NoContent();
        }
    }
}
