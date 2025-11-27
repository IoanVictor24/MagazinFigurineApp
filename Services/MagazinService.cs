using MagazinFigurineApp.Models;
using MagazinFigurineApp.Repositories.Interfaces;
using MagazinFigurineApp.Services.Intefaces;

namespace MagazinFigurineApp.Services
{
    public class MagazinService : IMagazinService
    {
        private readonly IMagazinRepository _magazinRepository;
        public MagazinService(IMagazinRepository magazinRepository)
        {
            _magazinRepository = magazinRepository;
        }
        public IEnumerable<Magazin> GetAllMagazine()
        {
            return _magazinRepository.FindAll().ToList();
        }
        public Magazin? GetMagazinById(int id)
        {
            return _magazinRepository.FindByCondition(m => m.MagazinID == id).FirstOrDefault();
        }
        public void AddMagazin(Magazin magazin)
        {
            _magazinRepository.Create(magazin);
            _magazinRepository.Save();
        }
        public void UpdateMagazin(Magazin magazin)
        {
            _magazinRepository.Update(magazin);
            _magazinRepository.Save();
        }
        public void DeleteMagazin(int id)
        {
            var magazin = GetMagazinById(id);
            if (magazin != null)
            {
                _magazinRepository.Delete(magazin);
                _magazinRepository.Save();
            }
        }
    }
}
