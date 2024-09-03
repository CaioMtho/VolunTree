using Microsoft.AspNetCore.Mvc;
using VolunTree_API.Models;
using VolunTree_API.Services;

namespace VolunTree_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoluntariosController : ControllerBase
    {
        private readonly IDataService _dataService;

        public VoluntariosController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voluntario>>> GetVoluntarios()
        {
            var voluntarios = await _dataService.GetVoluntariosAsync();
            return Ok(voluntarios);
        }

        [HttpGet("{cpf}")]
        public async Task<ActionResult<Voluntario>> GetVoluntario(string cpf)
        {
            var voluntario = await _dataService.GetVoluntarioByIdAsync(cpf);

            if (voluntario == null)
            {
                return NotFound();
            }

            return Ok(voluntario);
        }

        [HttpPost]
        public async Task<ActionResult> PostVoluntario(Voluntario voluntario)
        {
            await _dataService.AddVoluntarioAsync(voluntario);
            return CreatedAtAction(nameof(GetVoluntario), new { cpf = voluntario.Cpf }, voluntario);
        }

        [HttpPut("{cpf}")]
        public async Task<IActionResult> PutVoluntario(string cpf, Voluntario voluntario)
        {
            if (cpf != voluntario.Cpf)
            {
                return BadRequest();
            }

            await _dataService.UpdateVoluntarioAsync(voluntario);
            return NoContent();
        }

        [HttpDelete("{cpf}")]
        public async Task<IActionResult> DeleteVoluntario(string cpf)
        {
            await _dataService.DeleteVoluntarioAsync(cpf);
            return NoContent();
        }
    }

}
