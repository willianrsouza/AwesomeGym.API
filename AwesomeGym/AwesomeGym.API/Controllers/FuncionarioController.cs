using AwesomeGym.Infrastructure.Persistencia.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeGym.API.Controllers
{
    [Route("api/funcionarios")]
    public class FuncionarioController : ControllerBase
    {

        private readonly FuncionarioDbContext _funcionarioDbContext;
        public FuncionarioController(FuncionarioDbContext funcionarioDbContext)
        {
            _funcionarioDbContext = funcionarioDbContext;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var funcioarios = _funcionarioDbContext.Funcionario.ToList();
            return Ok(funcioarios);

        }


    }
}
