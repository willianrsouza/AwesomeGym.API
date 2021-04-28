using AwesomeGym.Application.Entidades;
using AwesomeGym.Application.InputModels;
using AwesomeGym.Infrastructure.Persistencia.Servicos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AwesomeGym.API.Controllers
{
    [Route("api/alunos")]
    public class AlunoController : ControllerBase
    {


        private readonly AlunoDbContext _alunoDbContext;

        public AlunoController(AlunoDbContext alunoDbContext)
        {
            _alunoDbContext = alunoDbContext;
        }


        [HttpGet]

        public IActionResult Get()
        {
            var alunos = _alunoDbContext.Alunos.ToList();
            return Ok(alunos);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
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
        public IActionResult Post([FromBody] AlunoInputModel alunoInputModel)
        {
            if (alunoInputModel == null)
            {
                return NotFound();
            }

            
            Alunos aluno = new Alunos(alunoInputModel.nomeAluno, alunoInputModel.cpfAluno);

            //Adicionando e Salvando a operação
            _alunoDbContext.Alunos.Add(aluno);
            _alunoDbContext.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = aluno.id }, aluno);

        }


    }
}
