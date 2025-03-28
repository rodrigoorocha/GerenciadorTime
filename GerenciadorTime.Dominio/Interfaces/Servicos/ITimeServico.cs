using GerenciadorTime.Dominio.classes;
using GerenciadorTime.Dominio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTime.Dominio.Interfaces.Servicos
{
    public interface ITimeServico
    {
        Task<IEnumerable<Time>?> ObterTodos();
        Task<Time?> ObterPorId(Guid id);
        Task<Guid> Adicionar(TimeAtualizarDTO time);
        Task<bool> Atualizar(Guid id, TimeAtualizarDTO time);
        Task<bool> Deletar(Guid id);
    }
}
