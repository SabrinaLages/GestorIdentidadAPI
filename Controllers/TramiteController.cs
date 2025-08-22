using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.Generic;
using PrimerParcial.Interfaces;
using PrimerParcial.Models;


namespace PrimerParcial.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TramiteController(ITramiteRepository _tramiteRepository) : ControllerBase
    {


        [HttpGet("GetLosTramitesActivos")]
        public async Task<List<TramiteModel>> GetUsersModel()
        {
            var response = await _tramiteRepository.GetAllTramitesModelAsync();
            return response;

        }

        [HttpPost("ActualizarPrecio/{id}")]
        public async Task<IActionResult> ActualizarPrecio(int id, [FromBody] int nuevoPrecio)
        {
            var resultado = await _tramiteRepository.UpdatePrecioById(id, nuevoPrecio);
            if (!resultado)
                return NotFound($"Tramite con id {id} no encontrado.");

            return Ok("Precio actualizado correctamente.");
        }


        [HttpPost("CambiarEstado/{id}")]
        public async Task<IActionResult> CambiarEstado(int id, [FromBody] bool nuevoEstado)
        {
            var resultado = await _tramiteRepository.CambiarEstadoTramite(id, nuevoEstado);
            if (!resultado)
                return NotFound("Tramite no encontrado");

            return Ok("Estado actualizado correctamente");
        }

    }
}
