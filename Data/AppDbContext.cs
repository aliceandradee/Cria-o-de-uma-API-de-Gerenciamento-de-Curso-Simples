using APIGerenciamentodoCurso.Models;
using Microsoft.EntityFrameworkCore;

namespace APIGerenciamentodoCurso.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //onde cria a tabela cursos no meu banco de dados
        public DbSet<Curso> Cursos { get; set; }
    }
}