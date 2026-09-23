using ApiGestaoProcessos.Dtos;
using ApiGestaoProcessos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace ApiGestaoProcessos.Controllers
{
    [Route("clientes")]
    [ApiController]
    public class ClienteController(ClienteService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var clientes = await _service.FindAll();

                return Ok(clientes);

            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteDto data)
        {
            try
            {
                var cliente = await _service.Create(data);

                return Created("", cliente);

            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
