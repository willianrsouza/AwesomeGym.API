using AwesomeGym.Application.Entidades;
using AwesomeGym.Application.InputModels;
using AwesomeGym.Infrastructure.Persistencia.Servicos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AwesomeGym.API.Controllers
{
    [Route("api/aluno")]
    public class AlunoController : ControllerBase
    {

        private readonly AlunoDbContext _alunoDbContext;

        public AlunoController(AlunoDbContext alunoDbContext)
        {
            _alunoDbContext = alunoDbContext;
        }


        [HttpGet]

        public IActionResult GetAlunos()
        {
            var alunos = _alunoDbContext.Alunos.ToList();
            return Ok(alunos);
        }


        [HttpGet("{id}")]

        public IActionResult GetAlunosById(int id)
        {
            //SingleOrDefault  = Extensão que retorna um elemento especifico dentro de uma List

            var alunos = _alunoDbContext.Alunos.SingleOrDefault(p => p.id == id);

            if (alunos == null)
            {
                return NotFound();
            }
            return Ok(alunos);
        }

        [HttpPost]
        public IActionResult PostAlunos([FromBody] AlunoInputModel alunoInputModel)
        {
            if (alunoInputModel == null)
            {
                return NotFound();
            }

            Alunos aluno = new Alunos(alunoInputModel.nomeAluno, alunoInputModel.cpfAluno);

            _alunoDbContext.Alunos.Add(aluno);
            _alunoDbContext.SaveChanges();

            return CreatedAtAction(nameof(GetAlunosById), new { id = aluno.id }, aluno);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAlunoById(int id)
        {
            var aluno = _alunoDbContext.Alunos.SingleOrDefault(p => p.id == id);
            _alunoDbContext.Remove(aluno);
            _alunoDbContext.SaveChanges();
            return Ok(aluno);
        }


    } 
}
