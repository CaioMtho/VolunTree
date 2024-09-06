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

        public OngsController(IDataService dataService)
        {
            _dataService = dataService;
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
            await _dataService.AddOngAsync(ong);
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
