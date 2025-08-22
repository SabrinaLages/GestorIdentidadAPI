using Microsoft.EntityFrameworkCore;
using PrimerParcial.EF;
using PrimerParcial.Interfaces;
using PrimerParcial.Models;

namespace PrimerParcial.Repositories
{
    public class TitularRepository(MiDBContext _context) :ITitularRepository
    {
        public async Task<List<TitularModel>> ObtenerExtranjerosPorDni()
        {
            var extranjeros = await _context.Titulares
                .Where(t =>
                    (t.Dni >= 92000000 && t.Dni < 96000000) 
                )
                .OrderBy(t => t.Dni)
                .Select(t => new TitularModel
                {
     
                    Nombre = t.FirstName,
                    Apellido = t.LastName,
                    Dni = t.Dni,
                    NumeroTramite = t.NumeroTramite,
                    
                })
                .ToListAsync();

            return extranjeros;
        }

        public async Task<bool> RegistrarTitularAsync(TitularModel model)
        {
            var existe = await _context.Titulares.AnyAsync(t => t.Dni == model.Dni && t.NumeroTramite == model.NumeroTramite);
            if (existe)
                return false;

            var nuevo = new Titulare
            {
                FirstName = model.Nombre,
                LastName = model.Apellido,
                Dni = model.Dni,
                NumeroTramite = model.NumeroTramite
            };

            _context.Titulares.Add(nuevo);
            var guardado = await _context.SaveChangesAsync();
            return guardado > 0;
        }

    }
}
