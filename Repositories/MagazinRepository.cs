using MagazinFigurineApp.Context;
using MagazinFigurineApp.Model;
using MagazinFigurineApp.Models;
using MagazinFigurineApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagazinFigurineApp.Repositories
{
    public class MagazinRepository : IMagazinRepository
    {
        private MagazinFigurineContext _context;
        public MagazinRepository(MagazinFigurineContext context)
        {
            _context = context;
        }
        public void Create(Magazin magazin)
        {
            _context.Magazine.Add(magazin);
        }
        public void Delete(Magazin magazin)
        {
            _context.Magazine.Remove(magazin);
        }
        public void Update(Magazin magazin)
        {
            _context.Magazine.Update(magazin);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public IQueryable<Magazin> FindAll() =>
            _context.Set<Magazin>().AsNoTracking();
        public IQueryable<Magazin> FindByCondition(Expression<Func<Magazin, bool>> expression) =>
            _context.Set<Magazin>().Where(expression).AsNoTracking();
    }
}
