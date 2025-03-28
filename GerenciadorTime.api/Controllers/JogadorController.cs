using GerenciadorTime.Dominio.classes;
using GerenciadorTime.Dominio.DTO;
using GerenciadorTime.Dominio.Interfaces.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTime.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogadorController(IJogadorServico servicoJogador) : ControllerBase
    {


        [Route("ObterTodos")]
        [HttpGet]
        public async  Task<IActionResult> ObterTodos()
        {
            
            return Ok(await servicoJogador.ObterTodos());
        }

        [Route("ObterPorID/{id}")]
        [HttpGet]
        public async Task<IActionResult> ObterLista([FromRoute] Guid id)
        {
            
            return Ok( await servicoJogador.ObterPorId(id));
        }


        [Route("CriarJogador")]
        [HttpPost] // https://0.0.0.0:000/api/Jogador/CriarJogador?jogadorAdicionarDTO=
        public async Task<IActionResult> Criar([FromBody] JogadorAdicionarDTO jogadorAdicionarDTO)
        {
            return Ok(await servicoJogador.Adicionar(jogadorAdicionarDTO));
        }

        [Route("AtualizarJogador/{id}")]
        [HttpPut]
        public async Task<IActionResult> Atualizar([FromRoute] Guid id, [FromBody] JogadorAdicionarDTO jogadorAdicionarDTO)
        {
            var resultado = await servicoJogador.Atualizar(id, jogadorAdicionarDTO);
            if (!resultado)
            {
                return NotFound();
            }
            return Ok();
        }

        [Route("DeletarJogador/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Deletar([FromRoute] Guid id)
        {
            var resultado = await servicoJogador.Deletar(id);
            if (!resultado)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
