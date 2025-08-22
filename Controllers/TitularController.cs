using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimerParcial.Interfaces;
using PrimerParcial.Models;


namespace PrimerParcial.Controllers
{
    public class TitularController(ITitularRepository _titularRepository) : Controller
    {
        [HttpGet("GetTitularesExtranjeros")]
        public async Task<ActionResult<List<TitularModel>>> ObtenerExtranjeros()
        {
            var extranjeros = await _titularRepository.ObtenerExtranjerosPorDni();
            return extranjeros;
        }

        [HttpPost("RegistrarTitular")]
        public async Task<IActionResult> RegistrarTitular([FromBody] TitularModel model)
        {
            var result = await _titularRepository.RegistrarTitularAsync(model);

            if (!result)
                return Conflict("Hay un error.");

            return Ok("Titular registrado correctamente.");
        }

    }
}
