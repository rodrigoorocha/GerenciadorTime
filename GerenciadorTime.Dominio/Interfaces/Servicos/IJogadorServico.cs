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
        Task<int> Adicionar(JogadorAdicionarDTO jogador);
    }
}
