using MagazinFigurineApp.Model;
using MagazinFigurineApp.Models;

namespace MagazinFigurineApp.Repositories.Interfaces
{
    public interface IFigurineRepository
    {
        IEnumerable<Figurina> GetAll();
        bool FigurineExists(int id);
        void Create(Figurina figurina);
        void Update(Figurina figurine);
        void Delete(Figurina figurina);
        void Save();
        Figurina GetById(int id);
        List<ComandaFigurina> GetAllComenziFigurine();
        List<Recenzie> GetAllReviews();
        List<Producator> GetAllProducatori();
        List<Magazin> GetAllMagazine();
        Figurina GetByIdWithRelatedEntities(int id);
    }
}
