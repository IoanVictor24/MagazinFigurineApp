using MagazinFigurineApp.Models;
using System.Threading.Tasks;

namespace MagazinFigurineApp.Services.Intefaces
{
    public interface IComandaService
    {
        Task CreazaComanda(string userId, Comanda dateLivrare);
    }
}