using GerenciadorTime.Dominio.classes;
using GerenciadorTime.Dominio.Classes;
using GerenciadorTime.Dominio.DTO;
using GerenciadorTime.Dominio.Interfaces.Repositorios;
using GerenciadorTime.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gerenciadorTime.Aplicacao.Servicos
{
    public class OlheiroServico : IOlheiroServico
    {
        private readonly IOlheiroRepositorio _olheiroRepositorio;

        public OlheiroServico(IOlheiroRepositorio olheiroRepositorio)
        {
            _olheiroRepositorio = olheiroRepositorio;
        }

        public async Task<IEnumerable<Olheiro>?> ObterTodos()
        {
            return await _olheiroRepositorio.GetAllAsync();
        }

        public async Task<Olheiro?> ObterPorId(Guid id)
        {
            return await _olheiroRepositorio.GetByIdAsync(id);
        }

        public Task<Guid> Adicionar(OlheiroAdicionarDTO olheiro)
        {
            return _olheiroRepositorio.SaveAsync(new Olheiro
            {
                Nome = olheiro.Nome,
                Experiencia = olheiro.Experiencia,
                TimeAtual = olheiro.TimeAtualId.HasValue ? new Time() { Id = olheiro.TimeAtualId.Value } : null,
                TimesAnteriores = olheiro.TimesAnterioresIds.ConvertAll(id => new Time() { Id = id }),
                JogadoresObservados = olheiro.JogadoresObservadosIds.ConvertAll(id => new Jogador() { Id = id })
            });
        }

        public async Task<bool> Atualizar(Guid id, OlheiroAdicionarDTO olheiro)
        {
            var olheiroExistente = await _olheiroRepositorio.GetByIdAsync(id);
            if (olheiroExistente == null)
            {
                return false;
            }

            olheiroExistente.Nome = olheiro.Nome;
            olheiroExistente.Experiencia = olheiro.Experiencia;
            olheiroExistente.TimeAtual = olheiro.TimeAtualId.HasValue ? new Time() { Id = olheiro.TimeAtualId.Value } : null;
            olheiroExistente.TimesAnteriores = olheiro.TimesAnterioresIds.ConvertAll(id => new Time() { Id = id });
            olheiroExistente.JogadoresObservados = olheiro.JogadoresObservadosIds.ConvertAll(id => new Jogador() { Id = id });

            await _olheiroRepositorio.SaveAsync(olheiroExistente);
            return true;
        }

        public async Task<bool> Deletar(Guid id)
        {
            var olheiroExistente = await _olheiroRepositorio.GetByIdAsync(id);
            if (olheiroExistente == null)
            {
                return false;
            }

            await _olheiroRepositorio.DeleteAsync(id);
            return true;
        }
    }
}
