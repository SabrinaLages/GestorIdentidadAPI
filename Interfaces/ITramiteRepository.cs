using PrimerParcial.Models;
using PrimerParcial.EF;

namespace PrimerParcial.Interfaces
{
    public interface ITramiteRepository
    {
        
        Task<List<TramiteModel>> GetAllTramitesModelAsync();

        Task<bool> UpdatePrecioById(int id, int nuevoPrecio);

        Task<bool> CambiarEstadoTramite(int id, bool nuevoEstado);

    }
}
