using MagazinFigurineApp.Models;
using System.Threading.Tasks;

namespace MagazinFigurineApp.Repositories.Interfaces
{
    public interface IComandaRepository
    {
        Task CreateComanda(Comanda comanda);
    }
}