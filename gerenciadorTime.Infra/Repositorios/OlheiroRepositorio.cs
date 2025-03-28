using gerenciadorTime.Infra.Context;
using GerenciadorTime.Dominio.classes;
using GerenciadorTime.Dominio.Classes;
using GerenciadorTime.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gerenciadorTime.Infra.Repositorios
{
    public class OlheiroRepositorio : Repositorio<Olheiro>, IOlheiroRepositorio
    {
        public OlheiroRepositorio(DbContextGerenciadorTime context) : base(context)
        {
        }
    }
}
