using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Models;
using PruebaTecnica.Service.IRepository;

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenisController : ControllerBase
    {
        private ITenisRepository _TenisRepository;
        public TenisController(ITenisRepository TenisRepository)
        {
            _TenisRepository = TenisRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTenis()
        {
            return Ok(await _TenisRepository.GetTenis());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeniById(int id)
        {
            var Teni = await _TenisRepository.GetTenisById(id);

            if (Teni == null)
            {
                return NoContent();
            }

            return Ok(Teni);
        }

        [HttpPost]
        public async Task<IActionResult> PostTeni(Tenis Teni)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelState();
            }

            await _TenisRepository.PostTenis(Teni);

            return Ok();

        }

        [HttpPut]
        public async Task<IActionResult> PutTeni(int id, Tenis Teni)
        {
            if (id != Teni.id)
            {
                return BadRequest();
            }

            if (await _TenisRepository.UpdateTenis(id, Teni) == -1)
            {
                return BadRequest("Teni no existe");
            }
            else
            {
                return await GetTeniById(id);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTeni(int id)
        {
            if (await _TenisRepository.DeleteTenisById(id) == -1)
            {
                return BadRequest("Teni no existe");
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
