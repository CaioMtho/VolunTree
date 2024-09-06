using Microsoft.AspNetCore.Mvc;
using VolunTree_API.Services;
using VolunTree_API.Models;
namespace VolunTree_API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class SugestoesController : ControllerBase
    {
            private readonly IDataService _dataService;

            public SugestoesController(IDataService dataService)
            {
                _dataService = dataService;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Sugestao>>> GetSugestoes()
            {
                var sugestoes = await _dataService.GetSugestoesAsync();
                return Ok(sugestoes);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Sugestao>> GetSugestao(int id)
            {
                var sugestao = await _dataService.GetSugestaoByIdAsync(id);

                if (sugestao == null)
                {
                    return NotFound();
                }

                return Ok(sugestao);
            }

            [HttpPost]
            public async Task<ActionResult> PostSugestao(Sugestao sugestao)
            {
                await _dataService.AddSugestaoAsync(sugestao);
                return CreatedAtAction(nameof(GetSugestao), new { id = sugestao.IdSuges }, sugestao);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> PutSugestao(int id, Sugestao sugestao)
            {
                if (id != sugestao.IdSuges)
                {
                    return BadRequest();
                }

                await _dataService.UpdateSugestaoAsync(sugestao);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteSugestao(int id)
            {
                await _dataService.DeleteSugestaoAsync(id);
                return NoContent();
            }
        }

    }
