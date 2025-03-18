using gerenciadorTime.Infra.Context;
using GerenciadorTime.Dominio.classes;
using GerenciadorTime.Dominio.Interfaces.Repositorios;


namespace gerenciadorTime.Infra.Repositorios
{
    class TimeRepositorio : Repositorio<Time>, ITimeRepositorio
    {
        public TimeRepositorio(DbContextGerenciadorTime context) : base(context)
        {
        }
    }
}
