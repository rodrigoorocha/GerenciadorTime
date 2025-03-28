using GerenciadorTime.Dominio.Classes;

namespace GerenciadorTime.Dominio.DTO
{
    public class OlheiroAdicionarDTO
    {
        public string Nome { get; set; }
        public int Experiencia { get; set; }
        public Guid? TimeAtualId { get; set; }
        public List<Guid> TimesAnterioresIds { get; set; }
        public List<Guid> JogadoresObservadosIds { get; set; }
    }
}
