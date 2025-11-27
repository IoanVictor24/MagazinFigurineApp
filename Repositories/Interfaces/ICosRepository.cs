using MagazinFigurineApp.Models;

namespace MagazinFigurineApp.Repositories.Interfaces
{
    public interface ICosRepository
    {
        Task AdaugaInCos(Cos item);
        Task<List<Cos>> GetCosByUserId(string userId);
        Task ActualizeazaCantitate(int cosId, int cantitate);
        Task StergeDinCos(int id);
        Task<Cos> GetItemById(int id);
    }
}