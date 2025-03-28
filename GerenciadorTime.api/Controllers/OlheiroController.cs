using GerenciadorTime.Dominio.Classes;
using GerenciadorTime.Dominio.DTO;
using GerenciadorTime.Dominio.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GerenciadorTime.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OlheiroController(IOlheiroServico servicoOlheiro) : ControllerBase
    {
        [Route("ObterTodos")]
        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(await servicoOlheiro.ObterTodos());
        }

        [Route("ObterPorID/{id}")]
        [HttpGet]
        public async Task<IActionResult> ObterPorId([FromRoute] Guid id)
        {
            return Ok(await servicoOlheiro.ObterPorId(id));
        }

        [Route("CriarOlheiro")]
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] OlheiroAdicionarDTO olheiroAdicionarDTO)
        {
            return Ok(await servicoOlheiro.Adicionar(olheiroAdicionarDTO));
        }

        [Route("AtualizarOlheiro/{id}")]
        [HttpPut]
        public async Task<IActionResult> Atualizar([FromRoute] Guid id, [FromBody] OlheiroAdicionarDTO olheiroAdicionarDTO)
        {
            var resultado = await servicoOlheiro.Atualizar(id, olheiroAdicionarDTO);
            if (!resultado)
            {
                return NotFound();
            }
            return Ok();
        }

        [Route("DeletarOlheiro/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Deletar([FromRoute] Guid id)
        {
            var resultado = await servicoOlheiro.Deletar(id);
            if (!resultado)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
