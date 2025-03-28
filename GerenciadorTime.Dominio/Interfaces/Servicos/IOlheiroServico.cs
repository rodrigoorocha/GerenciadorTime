using GerenciadorTime.Dominio.classes;
using GerenciadorTime.Dominio.Classes;
using GerenciadorTime.Dominio.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorTime.Dominio.Interfaces.Servicos
{
    public interface IOlheiroServico
    {
        Task<IEnumerable<Olheiro>?> ObterTodos();
        Task<Olheiro?> ObterPorId(Guid id);
        Task<Guid> Adicionar(OlheiroAdicionarDTO olheiroAdicionarDTO);
        Task<bool> Atualizar(Guid id, OlheiroAdicionarDTO olheiroAdicionarDTO);
        Task<bool> Deletar(Guid id);
    }
}
