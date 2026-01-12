using MagazinFigurineApp.Models;
using MagazinFigurineApp.Repositories.Interfaces;
using MagazinFigurineApp.Services.Intefaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagazinFigurineApp.Services
{
    public class CosService : ICosService
    {
        private readonly ICosRepository _repository;

        public CosService(ICosRepository repository)
        {
            _repository = repository;
        }

        public async Task AdaugaInCos(string userId, int figurinaId, int cantitate)
        {
            await _repository.AdaugaInCos(new Cos
            {
                UtilizatorId = userId,
                FigurinaId = figurinaId,
                Cantitate = cantitate
            });
        }

        public async Task<List<Cos>> GetCos(string userId)
        {
            return await _repository.GetCosByUserId(userId);
        }

        public async Task ActualizeazaCantitate(int cosId, int cantitate)
        {
            await _repository.ActualizeazaCantitate(cosId, cantitate);
        }

        public async Task StergeDinCos(int id)
        {
            await _repository.StergeDinCos(id);
        }

        public async Task<decimal> CalculeazaTotal(string userId)
        {
            return await _repository.CalculeazaTotal(userId);
        }

        public Task GolesteCos(string userId)
        {
            throw new NotImplementedException();
        }

        public Task StergeDinCos(object cosID)
        {
            throw new NotImplementedException();
        }
    }
}