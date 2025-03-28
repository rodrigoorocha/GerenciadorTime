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

        public async Task<bool> Atualizar(Guid id, JogadorAdicionarDTO jogador)
        {
            var jogadorExistente = await _jogadorRepositorio.GetByIdAsync(id);
            if (jogadorExistente == null)
            {
                return false;
            }

            jogadorExistente.DataNascimento = jogador.DataNascimento;
            jogadorExistente.Nome = jogador.Nome;
            jogadorExistente.Posicao = (GerenciadorTime.Dominio.classes.Posicao)jogador.Posicao;
            jogadorExistente.Time = jogador.TimeId.HasValue ? new Time() { Id = jogador.TimeId.Value } : null;

            await _jogadorRepositorio.SaveAsync(jogadorExistente);
            return true;
        }

        public async Task<bool> Deletar(Guid id)
        {
            var jogadorExistente = await _jogadorRepositorio.GetByIdAsync(id);
            if (jogadorExistente == null)
            {
                return false;
            }

            await _jogadorRepositorio.DeleteAsync(id);
            return true;
        }
    }
}
