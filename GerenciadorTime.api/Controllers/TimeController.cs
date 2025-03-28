using GerenciadorTime.Dominio.classes;
using GerenciadorTime.Dominio.DTO;
using GerenciadorTime.Dominio.Interfaces.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTime.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController(ITimeServico servicoTime) : ControllerBase
    {
        [Route("ObterTodos")]
        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(await servicoTime.ObterTodos());
        }

        [Route("ObterPorID/{id}")]
        [HttpGet]
        public async Task<IActionResult> ObterPorId([FromRoute] Guid id)
        {
            return Ok(await servicoTime.ObterPorId(id));
        }

        [Route("CriarTime")]
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] TimeAtualizarDTO timeAdicionarDTO)
        {
            return Ok(await servicoTime.Adicionar(timeAdicionarDTO));
        }

        [Route("AtualizarTime/{id}")]
        [HttpPut]
        public async Task<IActionResult> Atualizar([FromRoute] Guid id, [FromBody] TimeAtualizarDTO timeAdicionarDTO)
        {
            var resultado = await servicoTime.Atualizar(id, timeAdicionarDTO);
            if (!resultado)
            {
                return NotFound();
            }
            return Ok();
        }

        [Route("DeletarTime/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Deletar([FromRoute] Guid id)
        {
            var resultado = await servicoTime.Deletar(id);
            if (!resultado)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
