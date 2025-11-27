using MagazinFigurineApp.Model;

namespace MagazinFigurineApp.Services.Intefaces
{
    public interface IProducatorService
    {
        IEnumerable<Producator> GetAllProducatori();
        Producator? GetProducatorById(int id);
        void AddProducator(Producator producator);
        void UpdateProducator(Producator producator);
        void DeleteProducator(int id);

    }
}
