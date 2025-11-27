using MagazinFigurineApp.Context;
using MagazinFigurineApp.Model;
using MagazinFigurineApp.Models;
using MagazinFigurineApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MagazinFigurineApp.Repositories
{
    public class FigurineRepository : IFigurineRepository
    {
        private MagazinFigurineContext _context;
        public FigurineRepository(MagazinFigurineContext context)
        {
            _context = context;
        }

        public void Create(Figurina figurina)
        {
            _context.Figurine.Add(figurina);
        }

        public void Delete(Figurina figurina)
        {
            _context.Figurine.Remove(figurina);
        }

        public Figurina GetByIdWithRelatedEntities(int id)
        {
            return _context.Figurine.Include(a => a.Producator)
                   .Include(a => a.Magazin)
                .FirstOrDefault(m => m.FigurinaID == id);
        }
        public IEnumerable<Figurina> GetAll()
        {
            return _context.Figurine
                .Include(s => s.ComenziFigurine)
                .ThenInclude(sa => sa.Comanda)
                .Include(s => s.Recenzii)
                .Include(s => s.Producator)
                .Include(s => s.Magazin);
        }
        public List<ComandaFigurina> GetAllComenziFigurine()
        {
            return _context.ComenziFigurine.ToList();
        }
        public List<Producator> GetAllProducatori()
        {
            return _context.Producatori.ToList();
        }
        public List<Recenzie> GetAllReviews()
        {
            return _context.Recenzii.ToList();
        }

        public List<Magazin> GetAllMagazine()
        {
            return _context.Magazine.ToList();
        }
        public Figurina GetById(int id)
        {
            return _context.Figurine
                .Include(s => s.ComenziFigurine)
                .ThenInclude(sa => sa.Comanda)
                .Include(s => s.Recenzii)
                .Include(s => s.Producator)
                .Include(s => s.Magazin)
                .FirstOrDefault(m => m.FigurinaID == id);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public bool FigurineExists(int id)
        {
            return _context.Figurine.Any(o => o.FigurinaID == id);
        }
        public void Update(Figurina figurina)
        {
            _context.Figurine.Update(figurina);
        }
    }
}
