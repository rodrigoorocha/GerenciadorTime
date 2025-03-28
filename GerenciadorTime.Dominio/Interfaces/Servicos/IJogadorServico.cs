using GerenciadorTime.Dominio.classes;
using GerenciadorTime.Dominio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorTime.Dominio.Interfaces.Servicos
{
    public interface IJogadorServico
    {
        Task<IEnumerable<Jogador>?> ObterTodos();
        Task<Jogador?> ObterPorId(Guid id);
        Task<Guid> Adicionar(JogadorAdicionarDTO jogador);
        Task<bool> Atualizar(Guid id, JogadorAdicionarDTO jogador);
        Task<bool> Deletar(Guid id);
    }
}
