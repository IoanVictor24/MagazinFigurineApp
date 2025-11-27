using MagazinFigurineApp.Context;
using MagazinFigurineApp.Model;
using MagazinFigurineApp.Models;
using MagazinFigurineApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagazinFigurineApp.Repositories
{
    public class ProducatorRepository : IProducatorRepository
    {
        private MagazinFigurineContext _context;
        public ProducatorRepository(MagazinFigurineContext context)
        {
            _context = context;
        }

        public void Create(Producator producator)
        {
            _context.Producatori.Add(producator);
        }

        public void Delete(Producator producator)
        {
            _context.Producatori.Remove(producator);

        }
        public  void Update(Producator producator)
        {
            _context.Producatori.Update(producator);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public IQueryable<Producator> FindAll() =>
            _context.Set<Producator>().AsNoTracking();
        public IQueryable<Producator> FindByCondition(Expression<Func<Producator, bool>> expression) =>
            _context.Set<Producator>().Where(expression).AsNoTracking();
    }
    
}
