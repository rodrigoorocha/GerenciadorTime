
using gerenciadorTime.Aplicacao.Servicos;
using gerenciadorTime.Infra.Context;
using gerenciadorTime.Infra.Repositorios;
using GerenciadorTime.Dominio.Interfaces.Repositorios;
using GerenciadorTime.Dominio.Interfaces.Servicos;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTime.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // DI - Services
            builder.Services.AddScoped<IJogadorServico, JogadorServico>();
            // DI - Repositories
            builder.Services.AddScoped<IJogadorRepositorio, JogadorRepositorio>();
            // Add services to the container.
            builder.Services.AddDbContext<DbContextGerenciadorTime>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
