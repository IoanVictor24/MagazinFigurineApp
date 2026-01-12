using MagazinFigurineApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagazinFigurineApp.Repositories.Interfaces
{
    public interface ICosRepository
    {
        Task AdaugaInCos(Cos item);
        Task<List<Cos>> GetCosByUserId(string userId);
        Task ActualizeazaCantitate(int cosId, int cantitate);
        Task StergeDinCos(int id);
        Task<decimal> CalculeazaTotal(string userId);
        Task<Cos> GetItemById(int id);
    }
}