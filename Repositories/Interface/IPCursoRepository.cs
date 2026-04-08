using APIGerenciamentodoCurso.Models;

namespace APIGerenciamentodoCurso.Repositories.Interface
{
    public interface IPCursoRepository
    {
        // criando o get que vaui listar todos os cursos
        Task<IEnumerable<Curso>> GetAll();

        // crisndo o get que vai atualizar todos os cursos
        Task<Curso> GetById(int id);

        // criando o put que vai ser responsável pela criação de uma nova materia
        Task Create(Curso curso);

        // criando o put que vai ser responsável pela ATUALIZAÇÃO (o que foi pedido)
        Task Update(Curso curso);

        // deletando alguma materia 
        Task Delete(int id);

        // 6. A Regra de Ouro do Professor (Validar nome)
        Task<bool> VerificarSeNomeExiste(string nome, int id);
    }
}