using MagazinFigurineApp.Model;
using MagazinFigurineApp.Repositories.Interfaces;
using MagazinFigurineApp.Services.Intefaces;
using System.Linq.Expressions;

namespace MagazinFigurineApp.Services
{
    public class ProducatorService : IProducatorService
    {
        private readonly IProducatorRepository _producatorRepository;
        public ProducatorService(IProducatorRepository producatorRepository)
        {
            _producatorRepository = producatorRepository;
        }
        public IEnumerable<Producator> GetAllProducatori()
        {
            return _producatorRepository.FindAll().ToList();
        }
        public Producator? GetProducatorById(int id)
        {
            return _producatorRepository.FindByCondition(p => p.ID == id).FirstOrDefault();
        }
        public void AddProducator(Producator producator)
        {
            _producatorRepository.Create(producator);
            _producatorRepository.Save();
        }
        public void UpdateProducator(Producator producator)
        {
            _producatorRepository.Update(producator);
            _producatorRepository.Save();
        }
        public void DeleteProducator(int id)
        {
            var producator = GetProducatorById(id);
            if (producator != null)
            {
                _producatorRepository.Delete(producator);
                _producatorRepository.Save();
            }
        }
    }
}
