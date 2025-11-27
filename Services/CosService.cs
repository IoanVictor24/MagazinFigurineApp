using MagazinFigurineApp.Models;
using MagazinFigurineApp.Repositories.Interfaces;
using MagazinFigurineApp.Services.Intefaces;

namespace MagazinFigurineApp.Services
{
    public class CosService : ICosService
    {
        private readonly ICosRepository _repository;
        public CosService(ICosRepository repository)
        {
            _repository = repository;
        }

        public async Task GolesteCos(string userId)
        {
            var items = await _repository.GetCosByUserId(userId);
            foreach (var item in items)
            {
                await _repository.StergeDinCos(item.Id);
            }
        }
        public async Task AdaugaInCos(string userId, int figurinaId, int cantitate = 1)
        {
            var item = new Cos { UtilizatorId = userId, FigurinaId = figurinaId, Cantitate = cantitate };
            await _repository.AdaugaInCos(item);
        }

        public async Task<List<Cos>> GetCos(string userId)
        {
            return await _repository.GetCosByUserId(userId);
        }

        public async Task StergeDinCos(int id)
        {
            await _repository.StergeDinCos(id);
        }

        public async Task<decimal> CalculeazaTotal(string userId)
        {
            var items = await _repository.GetCosByUserId(userId);
            return items.Sum(i => i.Figurina.Pret * i.Cantitate);
        }

        public Task ActualizeazaCantitate(int cosId, int cantitate)
        {
            throw new NotImplementedException();
        }
    }
}