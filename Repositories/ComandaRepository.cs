using MagazinFigurineApp.Context;
using MagazinFigurineApp.Models;
using MagazinFigurineApp.Repositories.Interfaces;
using System.Threading.Tasks;

namespace MagazinFigurineApp.Repositories
{
    public class ComandaRepository : IComandaRepository
    {
        private readonly MagazinFigurineContext _context;

        public ComandaRepository(MagazinFigurineContext context)
        {
            _context = context;
        }

        public async Task CreateComanda(Comanda comanda)
        {
            _context.Comenzi.Add(comanda);
            await _context.SaveChangesAsync();
        }
    }
}