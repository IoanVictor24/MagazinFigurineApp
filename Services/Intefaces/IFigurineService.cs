using MagazinFigurineApp.Model;
using MagazinFigurineApp.Models;

namespace MagazinFigurineApp.Services.Intefaces
{
    public interface IFigurineService
    {
        Figurina GetFigurinaById(int id);
        Task AddFigurina(Figurina figurina);
        Task UpdateFigurina(Figurina figurina);
        void DeleteFigurina(int id);
        Figurina GetFigurinaAndRelatedById(int id);
        List<Figurina> GetAllFigurine();
        List<ComandaFigurina> GetAllComenziFigurine();
        bool FigurinaExists(int id);
        List<Recenzie> GetAllReviews();
        List<Magazin> GetAllMagazine();
        List<Producator> GetAllProducatori();
        
    }
}
