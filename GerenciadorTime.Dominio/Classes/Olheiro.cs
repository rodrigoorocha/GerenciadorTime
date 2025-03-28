using gerenciadorTime.Compartilhado;
using GerenciadorTime.Dominio.classes;
using System;
using System.Collections.Generic;

namespace GerenciadorTime.Dominio.Classes
{
    public class Olheiro : Base
    {
        public string Nome { get; set; }
        public int Experiencia { get; set; } // Anos de experiência
        public Time? TimeAtual { get; set; } // Time atual do olheiro (pode ser null se for independente)
        public List<Time> TimesAnteriores { get; set; } = new List<Time>(); // Times onde já trabalhou
        public List<Jogador> JogadoresObservados { get; set; } = new List<Jogador>();

        public void AvaliarJogador(Jogador jogador)
        {
            Console.WriteLine($"Olheiro {Nome} avaliando jogador {jogador.Nome}...");
        }

        public void RecomendarParaTime(Jogador jogador, Time time)
        {
            if (time != null)
            {
                time.Jogadores.Add(jogador);
                Console.WriteLine($"{Nome} recomendou {jogador.Nome} para o time {time.Nome}.");
            }
        }
    }
}
