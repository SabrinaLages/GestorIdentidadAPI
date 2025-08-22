using Microsoft.EntityFrameworkCore;
using PrimerParcial.EF;
using PrimerParcial.Interfaces;
using PrimerParcial.Models;

namespace PrimerParcial.Repositories
{
    public class TramiteRepository(MiDBContext _context) : ITramiteRepository
    {
        public async Task<List<TramiteModel>> GetAllTramitesModelAsync()
        {
            List<TramiteModel> listadoaDevolver = new List<TramiteModel>();

            var todosLosUsuarios = await _context.Tramites.Where(u => u.EstaActivo).OrderBy(t => t.Costo).ToListAsync();

            foreach (var item in todosLosUsuarios)
            {
                TramiteModel tramiteToAdd = new TramiteModel();

                tramiteToAdd.Nombre = item.Name;
                tramiteToAdd.Costo = item.Costo;

                listadoaDevolver.Add(tramiteToAdd);
            }

            return listadoaDevolver;
        }

        public async Task<bool> UpdatePrecioById(int id, int nuevoPrecio)
        {
            try
            {
                var tramite = await _context.Tramites.FirstOrDefaultAsync(t => t.IdTramite == id);
                if (tramite == null)
                    return false;

                tramite.Costo = nuevoPrecio;

                var status = await _context.SaveChangesAsync();
                return status > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar precio: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> CambiarEstadoTramite(int id, bool nuevoEstado)
        {
            var tramite = await _context.Tramites.FindAsync(id);
            if (tramite == null)
                return false;

            tramite.EstaActivo = nuevoEstado;
            var guardado = await _context.SaveChangesAsync();
            return guardado > 0;
        }

    }
}
