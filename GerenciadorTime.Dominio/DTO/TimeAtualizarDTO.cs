using System;

namespace GerenciadorTime.Dominio.DTO
{
    public class TimeAtualizarDTO
    {
        public string Nome { get; set; }
        public string CaminhoEscudo { get; set; }
        public string Estado { get; set; }
        public int Defesa { get; set; }
        public int Meio { get; set; }
        public int Ataque { get; set; }
        public DateTime FundacaoTime { get; set; }
    }
}


