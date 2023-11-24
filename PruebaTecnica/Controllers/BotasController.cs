using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Models;
using PruebaTecnica.Service.IRepository;

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotasController : ControllerBase
    {
        private IBotasRepository _BotasRepository;
        public BotasController(IBotasRepository BotasRepository)
        {
            _BotasRepository = BotasRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBotas()
        {
            return Ok(await _BotasRepository.GetBotas());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBotaById(int id)
        {
            var Bota = await _BotasRepository.GetBotaById(id);

            if (Bota == null)
            {
                return NoContent();
            }

            return Ok(Bota);
        }

        [HttpPost]
        public async Task<IActionResult> PostBota(Botas Bota)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelState();
            }

            await _BotasRepository.PostBotas(Bota);

            return Ok();

        }

        [HttpPut]
        public async Task<IActionResult> PutBota(int id, Botas Bota)
        {
            if (id != Bota.id)
            {
                return BadRequest();
            }

            if (await _BotasRepository.UpdateBota(id, Bota) == -1)
            {
                return BadRequest("Bota no existe");
            }
            else
            {
                return await GetBotaById(id);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBota(int id)
        {
            if (await _BotasRepository.DeleteBotaById(id) == -1)
            {
                return BadRequest("Bota no existe");
            }
            else
            {
                return NoContent();
            }
        }

        private IActionResult BadRequestModelState()
        {
            IEnumerable<string> errors = ModelState.Values.SelectMany(x => x.Errors.Select(e => e.ErrorMessage));
            return BadRequest(errors);
        }
    }
}
