

using GerenciadorTime.Dominio.classes;

namespace GerenciadorTime.Dominio.DTO
{
    public class JogadorAdicionarDTO
    {
        public DateTime DataNascimento { get; set; }
        public string Nome { get; set; }
        public Posicao Posicao { get; set; }
        public Guid? TimeId { get; set; }
    }

    public enum Posicao
    {
        Goleiro,
        Zagueiro,
        Lateral,
        MeioCampo,
        Atacante
    }
}

