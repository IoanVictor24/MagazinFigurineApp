using MagazinFigurineApp.Models;

namespace MagazinFigurineApp.Services.Intefaces
{
    public interface IMagazinService
    {
        IEnumerable<Magazin> GetAllMagazine();
        Magazin? GetMagazinById(int id);
        void AddMagazin(Magazin magazin);
        void UpdateMagazin(Magazin magazin);
        void DeleteMagazin(int id);
    }
}
