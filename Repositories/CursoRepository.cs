using APIGerenciamentodoCurso.Data;
using APIGerenciamentodoCurso.Models;
using APIGerenciamentodoCurso.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace APIGerenciamentodoCurso.Repositories
{
    public class CursoRepository : IPCursoRepository
    {
        private readonly AppDbContext _context;
        // ligação com o banco de dados 
        public CursoRepository(AppDbContext context) { _context = context; }

        public async Task<IEnumerable<Curso>> GetAll() => await _context.Cursos.ToListAsync();

        // onde acontece a busca do id
        public async Task<Curso> GetById(int id) => await _context.Cursos.FindAsync(id);

        //metodo que ocorre a criação de um novo curso e salva através do SaveChangesAsync().
        public async Task Create(Curso curso)
        {
            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();
        }

        // metodo para atualizar o curso já existente e salva através do SaveChangesAsync().
        public async Task Update(Curso curso)
        {
            _context.Cursos.Update(curso);
            await _context.SaveChangesAsync();
        }

        // metodos para deletar o curso e todas suas informações e remover do banco
        public async Task Delete(int id)
        {
            var curso = await GetById(id);
            if (curso != null)
            {
                _context.Cursos.Remove(curso);
                await _context.SaveChangesAsync();
            }
        }

        // onde ocorre a tratativa do erro pedido verificando se o nome for igual ao id é que existe, se for diferente é porque é um nome novo 
        public async Task<bool> VerificarSeNomeExiste(string nome, int id)
        {
            return await _context.Cursos.AnyAsync(c => c.Name == nome && c.Id != id);
        }
    }
}