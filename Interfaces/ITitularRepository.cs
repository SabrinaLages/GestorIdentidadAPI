using PrimerParcial.Models;
using System.Threading.Tasks;

namespace PrimerParcial.Interfaces
{
    public interface ITitularRepository
    {

        Task<List<TitularModel>> ObtenerExtranjerosPorDni();

        Task<bool> RegistrarTitularAsync(TitularModel model);

    }
}