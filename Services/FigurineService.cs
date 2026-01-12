using MagazinFigurineApp.Services.Intefaces;
using MagazinFigurineApp.Repositories.Interfaces;
using MagazinFigurineApp.Models;
using MagazinFigurineApp.Model;

namespace MagazinFigurineApp.Services
{
    public class FigurineService : IFigurineService
    {
        private IFigurineRepository _figurineRepository;
        public FigurineService(IFigurineRepository figurineRepository)
        {
            _figurineRepository = figurineRepository;
        }
        public Figurina GetFigurinaById(int id)
        {
            return _figurineRepository.GetById(id);
        }

        public async Task AddFigurina(Figurina figurina)
        {
            if (figurina.ImageFile != null && figurina.ImageFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    await figurina.ImageFile.CopyToAsync(ms);
                    figurina.ImagineFigurina = ms.ToArray();
                }
            }
            figurina.DataLansare = figurina.DataLansare.ToUniversalTime();
            _figurineRepository.Create(figurina);
            _figurineRepository.Save();
        }
        public async Task UpdateFigurina(Figurina figurina)
        {
            using var ms = new MemoryStream();

            if (figurina.ImageFile != null && figurina.ImageFile.Length > 0)
            {
                await figurina.ImageFile.CopyToAsync(ms);
                figurina.ImagineFigurina = ms.ToArray();
            }
            _figurineRepository.Update(figurina);
            _figurineRepository.Save();
        }

        public void DeleteFigurina(int id)
        {
            var figurine = _figurineRepository.GetById(id);
            if (figurine != null)
            {
                _figurineRepository.Delete(figurine);
                _figurineRepository.Save();
            }
        }
        public Figurina GetFigurinaAndRelatedById(int id)
        {
            return _figurineRepository.GetByIdWithRelatedEntities(id);
        }

        public List<Figurina> GetAllFigurine()
        {
            return _figurineRepository.GetAll().ToList();
        }

        public List<ComandaFigurina> GetAllComenziFigurine()
        {
            return _figurineRepository.GetAllComenziFigurine().ToList();
        }
        public List<Recenzie> GetAllReviews()
        {
            return _figurineRepository.GetAllReviews().ToList();
        }
        public List<Producator> GetAllProducatori()
        {
            return _figurineRepository.GetAllProducatori().ToList();
        }
        public List<Magazin> GetAllMagazine()
        {
            return _figurineRepository.GetAllMagazine().ToList();
        }
        public bool FigurinaExists(int id)
        {
            return _figurineRepository.FigurineExists(id);
        }
    }
}
