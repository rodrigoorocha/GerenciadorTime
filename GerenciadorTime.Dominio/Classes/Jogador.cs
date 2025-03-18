
using gerenciadorTime.Compartilhado;

namespace GerenciadorTime.Dominio.classes;

public class Jogador : Base
{
    public DateTime DataNascimento { get; set; }
    public string Nome { get; set; }
    public Posicao Posicao { get; set; }
    public virtual Time? Time { get; set; }


}

public enum Posicao
{
    Goleiro,
    Zagueiro,
    Lateral,
    MeioCampo,
    Atacante
}
