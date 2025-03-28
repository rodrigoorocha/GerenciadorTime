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
    public class TimeServico : ITimeServico
    {
        private readonly ITimeRepositorio _timeRepositorio;

        public TimeServico(ITimeRepositorio timeRepositorio)
        {
            _timeRepositorio = timeRepositorio;
        }

        public async Task<IEnumerable<Time>?> ObterTodos()
        {
            return await _timeRepositorio.GetAllAsync();
        }

        public async Task<Time?> ObterPorId(Guid id)
        {
            return await _timeRepositorio.GetByIdAsync(id);
        }

        public Task<Guid> Adicionar(TimeAtualizarDTO time)
        {
            return _timeRepositorio.SaveAsync(new Time
            {
                Nome = time.Nome,
                CaminhoEscudo = time.CaminhoEscudo,
                Estado = time.Estado,
                Defesa = time.Defesa,
                Meio = time.Meio,
                Ataque = time.Ataque,
                FundacaoTime = time.FundacaoTime
            });
        }

        public async Task<bool> Atualizar(Guid id, TimeAtualizarDTO time)
        {
            var timeExistente = await _timeRepositorio.GetByIdAsync(id);
            if (timeExistente == null)
            {
                return false;
            }

            timeExistente.Nome = time.Nome;
            timeExistente.CaminhoEscudo = time.CaminhoEscudo;
            timeExistente.Estado = time.Estado;
            timeExistente.Defesa = time.Defesa;
            timeExistente.Meio = time.Meio;
            timeExistente.Ataque = time.Ataque;
            timeExistente.FundacaoTime = time.FundacaoTime;

            await _timeRepositorio.SaveAsync(timeExistente);
            return true;
        }

        public async Task<bool> Deletar(Guid id)
        {
            var timeExistente = await _timeRepositorio.GetByIdAsync(id);
            if (timeExistente == null)
            {
                return false;
            }

            await _timeRepositorio.DeleteAsync(id);
            return true;
        }
    }
}
