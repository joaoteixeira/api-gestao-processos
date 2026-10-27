using ApiGestaoProcessos.Dtos;
using ApiGestaoProcessos.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestaoProcessos.Controllers
{
    [Route("marcacoes")]
    [ApiController]
    public class MarcacaoController(MarcacaoService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await service.FindAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var marcacao = await service.FindById(id);

            return marcacao is null
                ? NotFound(new { Mensagem = $"Marcação {id} não encontrada" })
                : Ok(marcacao);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MarcacaoDto data)
        {
            var marcacao = await service.Create(data);

            return CreatedAtAction(nameof(GetById), new { id = marcacao.Id }, marcacao);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MarcacaoDto data)
        {
            var updated = await service.Update(id, data);

            return updated
                ? NoContent()
                : NotFound(new { Mensagem = $"Marcação {id} não encontrada" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await service.Delete(id);

            return deleted
                ? NoContent()
                : NotFound(new { Mensagem = $"Marcação {id} não encontrada" });
        }

        [HttpGet("{id}/processos")]
        public async Task<IActionResult> GetProcessos(int id)
        {
            var processos = await service.FindProcessos(id);

            return processos is null
                ? NotFound(new { Mensagem = $"Marcação {id} não encontrada" })
                : Ok(processos);
        }
    }
}
