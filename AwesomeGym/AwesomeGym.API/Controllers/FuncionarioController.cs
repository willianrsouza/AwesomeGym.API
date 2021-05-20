using AwesomeGym.Application.InputModels;
using AwesomeGym.Core.Entidades;
using AwesomeGym.Infrastructure.Persistencia.Servicos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AwesomeGym.API.Controllers
{

    [Route("api/funcionario")]
    [ApiController]

    public class FuncionarioController : ControllerBase
    {

        private readonly FuncionarioDbContext _funcionarioDbContext;
        public FuncionarioController(FuncionarioDbContext funcionarioDbContext)
        {
            _funcionarioDbContext = funcionarioDbContext;
        }


        [HttpGet]
        public IActionResult GetFuncionarios()
        {
            var funcioarios = _funcionarioDbContext.Funcionario.ToList();
            return Ok(funcioarios);

        }

        [HttpGet("{id}")]

        public IActionResult GetFuncionarioById(int id)
        {
            var funcionario = _funcionarioDbContext.Funcionario.SingleOrDefault(p => p.id == id);

            if (funcionario == null)
            {
                return NotFound();
            }
            return Ok(funcionario);
        }

        [HttpPost]

        public IActionResult PostFunconario([FromBody] FuncionarioInputModel funcionarioInputModel)
        {
            if (funcionarioInputModel == null)
            {
                return NotFound();
            }

            Funcionario funcionario = new Funcionario(funcionarioInputModel.NomeFuncionario, funcionarioInputModel.FuncionarioCpf);
            _funcionarioDbContext.Funcionario.Add(funcionario);
            _funcionarioDbContext.SaveChanges();

            return Ok(funcionario);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteFuncionarioById(int id)
        {
            var funcionario = _funcionarioDbContext.Funcionario.SingleOrDefault(p => p.id == id);

            _funcionarioDbContext.Remove(funcionario);
            _funcionarioDbContext.SaveChanges();
            return Ok(funcionario);
        }


    }
}
