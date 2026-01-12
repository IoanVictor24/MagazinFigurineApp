using MagazinFigurineApp.Models;

namespace MagazinFigurineApp.Services.Intefaces
{
    public interface ICosService
    {
        Task AdaugaInCos(string userId, int figurinaId, int cantitate = 1);
        Task<List<Cos>> GetCos(string userId);
        Task ActualizeazaCantitate(int cosId, int cantitate);
        Task StergeDinCos(int id);
        Task<decimal> CalculeazaTotal(string userId);
        Task GolesteCos(string userId);
        Task StergeDinCos(object cosID);
    }
}