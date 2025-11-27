using MagazinFigurineApp.Model;
using MagazinFigurineApp.Models;
using System.Linq.Expressions;

namespace MagazinFigurineApp.Repositories.Interfaces
{
    public interface IMagazinRepository
    {
        IQueryable<Magazin> FindAll();
        void Create(Magazin magazin);
        void Update(Magazin magazin);
        void Delete(Magazin magazin);
        void Save();
        IQueryable<Magazin> FindByCondition(Expression<Func<Magazin, bool>> expression);
    }
}
