using MagazinFigurineApp.Model;
using MagazinFigurineApp.Models;
using System.Linq.Expressions;

namespace MagazinFigurineApp.Repositories.Interfaces
{
    public interface IProducatorRepository
    {
        IQueryable<Producator> FindAll();
       // bool ProducatorExists(int id);
        void Create(Producator producator);
        void Update(Producator producator);
        void Delete(Producator producator);
        void Save();
        //Producator GetById(int id);
        IQueryable<Producator> FindByCondition(Expression<Func<Producator, bool>> expression);
        //List<ComandaFigurina> GetAllComenziFigurine();
        //List<Recenzie> GetAllReviews();
        //List<Producator> GetAllProducatori();
        //List<Magazin> GetAllMagazine();
        //Figurina GetByIdWithRelatedEntities(int id);
    }
}
