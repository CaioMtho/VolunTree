using Microsoft.AspNetCore.Mvc;
using VolunTree_API.Models;
using VolunTree_API.Services;

namespace VolunTree_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoluntarioOngsController : ControllerBase
    {
        private readonly IDataService _dataService;

        public VoluntarioOngsController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VoluntarioOng>>> GetVoluntarioOngs()
        {
            var voluntarioOngs = await _dataService.GetVoluntarioOngsAsync();
            return Ok(voluntarioOngs);
        }

        [HttpPost]
        public async Task<ActionResult> PostVoluntarioOng(VoluntarioOng voluntarioOng)
        {
            await _dataService.AddVoluntarioOngAsync(voluntarioOng);
            return CreatedAtAction(nameof(GetVoluntarioOngs), new { id = voluntarioOng.IdLigacao }, voluntarioOng);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoluntarioOng(int id)
        {
            await _dataService.DeleteVoluntarioOngAsync(id);
            return NoContent();
        }
    }


}
