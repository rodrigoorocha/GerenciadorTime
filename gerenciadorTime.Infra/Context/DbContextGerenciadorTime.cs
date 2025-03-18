

using GerenciadorTime.Dominio.classes;
using Microsoft.EntityFrameworkCore;

namespace gerenciadorTime.Infra.Context;

public class DbContextGerenciadorTime : DbContext
{
    public DbContextGerenciadorTime(DbContextOptions<DbContextGerenciadorTime> options) : base(options)
    {
    }
    public DbSet<Time> Times { get; set; }
    public DbSet<Jogador> Jogadores { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Time>()
            .HasMany(x=> x.Jogadores)
            .WithOne(x=> x.Time);


        modelBuilder.Entity<Jogador>()
            .HasOne(x => x.Time)
            .WithMany(x => x.Jogadores);


    }
}
