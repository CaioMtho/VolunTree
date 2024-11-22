using Microsoft.AspNetCore.Mvc;
using VolunTree_API.Models;
using VolunTree_API.Services;

namespace VolunTree_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OngsController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly CnpjService  _cnpjService;

        public OngsController(IDataService dataService, CnpjService cnpjService)
        {
            _dataService = dataService;
            _cnpjService = cnpjService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ong>>> GetOngs()
        {
            var ongs = await _dataService.GetOngsAsync();
            return Ok(ongs);
        }

        [HttpGet("{cnpj}")]
        public async Task<ActionResult<Ong>> GetOng(string cnpj)
        {
            var ong = await _dataService.GetOngByIdAsync(cnpj);

            if (ong == null)
            {
                return NotFound();
            }

            return Ok(ong);
        }

        [HttpPost]
        public async Task<ActionResult> PostOng(Ong ong)
{
            // Chama o serviço e aguarda o resultado
            var statusCode = await _cnpjService.RetornaCnpj(ong.Cnpj);

            // Verifica se o status da resposta é OK (200) ou outro status válido
            if (statusCode != System.Net.HttpStatusCode.OK)
            {
                return BadRequest();  // Retorna um erro se o CNPJ não for válido
            }

            // Adiciona a ONG no banco de dados (assumindo que o AddOngAsync é assíncrono)
            await _dataService.AddOngAsync(ong);

            // Retorna a resposta de sucesso com o status 201 Created
            return CreatedAtAction(nameof(GetOng), new { cnpj = ong.Cnpj }, ong);
        }


        [HttpPut("{cnpj}")]
        public async Task<IActionResult> PutOng(string cnpj, Ong ong)
        {
            if (cnpj != ong.Cnpj)
            {
                return BadRequest();
            }

            await _dataService.UpdateOngAsync(ong);
            return NoContent();
        }

        [HttpDelete("{cnpj}")]
        public async Task<IActionResult> DeleteOng(string cnpj)
        {
            await _dataService.DeleteOngAsync(cnpj);
            return NoContent();
        }
    }

}
