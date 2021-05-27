using AwesomeGym.Application.InputModels;
using AwesomeGym.Core.Entidades;
using AwesomeGym.Infrastructure.Persistencia.Servicos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AwesomeGym.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/equipamento")]
    [ApiController]
    public class EquipamentoController : ControllerBase
    {

        private readonly EquipamentosDbContext _equipamentoDbContext;


        public EquipamentoController(EquipamentosDbContext equipamentosDbContext)
        {
            _equipamentoDbContext = equipamentosDbContext;
        }

        [HttpGet]
        public IActionResult GetEquipamentos()
        {
            var equipamentos = _equipamentoDbContext.Equipamentos.ToList();
            return Ok(equipamentos);
        }

        [HttpGet("{id}")]

        public IActionResult GetEquipamentoById(int id)
        {
            if (_equipamentoDbContext == null)
            {
                return NotFound();
            }
            var equipamento = _equipamentoDbContext.Equipamentos.SingleOrDefault(p => p.id == id);
            return Ok(equipamento);
        }

        [HttpPost]
        public IActionResult PostEquipamento([FromBody] EquipamentoInputModel equipamentoInputModel)
        {
            if (equipamentoInputModel == null)
            {
                return NotFound();
            }

            Equipamento equipamentos = new Equipamento(equipamentoInputModel.nomeEquipamento, equipamentoInputModel.anoAdquirido);

            _equipamentoDbContext.Equipamentos.Add(equipamentos);
            _equipamentoDbContext.SaveChanges();

            return CreatedAtAction(nameof(GetEquipamentoById), new { id = equipamentos.id }, equipamentos);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEquipamentoById(int id)
        {
            var equipamento = _equipamentoDbContext.Equipamentos.SingleOrDefault(p => p.id == id);

            _equipamentoDbContext.Equipamentos.Remove(equipamento);
            _equipamentoDbContext.SaveChanges();
            return Ok(equipamento);
        }


    }
}
