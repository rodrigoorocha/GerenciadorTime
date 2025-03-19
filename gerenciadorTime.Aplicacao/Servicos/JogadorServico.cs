using GerenciadorTime.Dominio.classes;
using GerenciadorTime.Dominio.DTO;
using GerenciadorTime.Dominio.Interfaces.Repositorios;
using GerenciadorTime.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gerenciadorTime.Aplicacao.Servicos
{
  
    public class JogadorServico : IJogadorServico
    {
        private readonly IJogadorRepositorio _jogadorRepositorio;

        public JogadorServico(IJogadorRepositorio jogadorRepositorio)
        {
            _jogadorRepositorio = jogadorRepositorio;
        }

        public async Task<IEnumerable<Jogador>?> ObterTodos()
        {
            return await _jogadorRepositorio.GetAllAsync();
        }

        public async Task<Jogador?> ObterPorId(Guid id)
        {
            return await _jogadorRepositorio.GetByIdAsync(id);
        }

        public Task<Guid> Adicionar(JogadorAdicionarDTO jogador)
        {
          
          return  _jogadorRepositorio.SaveAsync(new Jogador
            {
                DataNascimento = jogador.DataNascimento,
                Nome = jogador.Nome,
                Posicao = (GerenciadorTime.Dominio.classes.Posicao)jogador.Posicao,
                Time = jogador.TimeId.HasValue ? new Time() { Id = jogador.TimeId.Value } : null
            });
        }
    }
}
