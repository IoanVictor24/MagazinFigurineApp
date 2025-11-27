using MagazinFigurineApp.Context;
using Microsoft.EntityFrameworkCore;
using MagazinFigurineApp.Models;
using MagazinFigurineApp.Repositories.Interfaces;

namespace MagazinFigurineApp.Repositories
{
    public class CosRepository : ICosRepository
    {
        private readonly MagazinFigurineContext _context;
        public CosRepository(MagazinFigurineContext context)
        {
            _context = context;
        }

        public Task ActualizeazaCantitate(int cosId, int cantitate)
        {
            throw new NotImplementedException();
        }

        public async Task AdaugaInCos(Cos item)
        {
            var existingItem = await _context.Cosuri
                .FirstOrDefaultAsync(c => c.UtilizatorId == item.UtilizatorId && c.FigurinaId == item.FigurinaId);

            if (existingItem != null)
            {
                existingItem.Cantitate += item.Cantitate;
            }
            else
            {
                _context.Cosuri.Add(item);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<Cos>> GetCosByUserId(string userId)
        {
            return await _context.Cosuri
                .Include(c => c.Figurina)
                .Where(c => c.UtilizatorId == userId)
                .ToListAsync();
        }

        public Task<Cos> GetItemById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task StergeDinCos(int id)
        {
            var item = await _context.Cosuri.FindAsync(id);
            if (item != null)
            {
                _context.Cosuri.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        // Alte metode...
    }
}