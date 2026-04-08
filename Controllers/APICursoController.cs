using APIGerenciamentodoCurso.Models;
using APIGerenciamentodoCurso.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace APIGerenciamentodoCurso.Controllers


{// essa parte aqui foi para conseguir a criação do banco
    [Route("api/[controller]")]
    [ApiController]
    public class APICursoController : ControllerBase
    {
        private readonly IPCursoRepository _repository;

        public APICursoController(IPCursoRepository repository)
        {
            _repository = repository;
        }

        // get onde vai listar os cursos
        [HttpGet]

        // esse comando pede ao Repository para buscar todos os dados na tabela do banco
        public async Task<IActionResult> Get()
        {
            var cursos = await _repository.GetAll();
            return Ok(cursos);
        }

        // put onde vai acontecer a minha tratativa de erro
        [HttpPut("{id}")]

        //esse comando/trativa de erro é onde  valida se os IDs batem e se o novo nome já existe no banco ou não
        public async Task<IActionResult> Put(int id, [FromBody] Curso curso)
        {
            try
            {
                if (id != curso.Id) return BadRequest("IDs não conferem!");

                var nomeJaExiste = await _repository.VerificarSeNomeExiste(curso.Name, id);

                //Caso o nome seja repetido, ele trava a operação e retorna o **Erro 500** que o professor pediu
                if (nomeJaExiste)
                {
                    return StatusCode(500, "Erro 500: Tentativa de atualizar curso com nome duplicado");
                }

                //se for um novo nome retorna '200 OK'

                await _repository.Update(curso);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // onde cria um novo usuario
        [HttpPost]

        // basicamente ele recebe os dados de um novo curso e envia para o 'Repository' salvar no banco de dados.
        public async Task<IActionResult> Post([FromBody] Curso curso)
        {
            await _repository.Create(curso);
            return CreatedAtAction(nameof(Get), new { id = curso.Id }, curso);
        }

        // comando para deletar um curso
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.Delete(id);
            return NoContent();
        }
    }
}