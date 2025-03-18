
using gerenciadorTime.Infra.Context;
using GerenciadorTime.Dominio.classes;
using GerenciadorTime.Dominio.Interfaces.Repositorios;

namespace gerenciadorTime.Infra.Repositorios;

public class JogadorRepositorio : Repositorio<Jogador>, IJogadorRepositorio
{
    public JogadorRepositorio(DbContextGerenciadorTime context) : base(context)
    {
    }
}
