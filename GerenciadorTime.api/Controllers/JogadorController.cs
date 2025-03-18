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
    }
}
