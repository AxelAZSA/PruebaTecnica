using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Models;
using PruebaTecnica.Service.IRepository;

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZapatosController : ControllerBase
    {
        private IZapatosRepository _zapatosRepository;
        public ZapatosController(IZapatosRepository zapatosRepository) 
        {
            _zapatosRepository = zapatosRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetZapatos() 
        { 
            return Ok(await _zapatosRepository.GetZapatos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetZapatoById(int id)
        {
            var zapato = await _zapatosRepository.GetZapatoById(id);

            if(zapato == null)
            {
                return NoContent();
            }

            return Ok(zapato);
        }

        [HttpPost]
        public async Task<IActionResult> PostZapato(Zapatos Zapato)
        {
            if(!ModelState.IsValid)
            {
                return BadRequestModelState();
            }

            await _zapatosRepository.PostZapato(Zapato);

            return Ok();

        }

        [HttpPut]
        public async Task<IActionResult> PutZapato(int id , Zapatos Zapato)
        {
            if (id != Zapato.id)
            {
                return BadRequest();
            }

            if (await _zapatosRepository.UpdateZapato(id, Zapato)== -1)
            {
                return BadRequest("Zapato no existe");
            }
            else
            {
                return await GetZapatoById(id);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteZapato(int id)
        {
            if(await _zapatosRepository.DeleteZapatoById(id) == -1)
            {
                return BadRequest("Zapato no existe");
            }
            else
            {
                return NoContent();
            }
        }

        private IActionResult BadRequestModelState() 
        { 
            IEnumerable<string> errors = ModelState.Values.SelectMany(x => x.Errors.Select(e=>e.ErrorMessage));
            return BadRequest(errors);
        } 
    }
}
