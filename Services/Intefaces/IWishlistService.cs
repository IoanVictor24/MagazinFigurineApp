using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagazinFigurineApp.Services.Intefaces
{
    public interface IWishlistService
    {
        Task AdaugaInWishlist(string userId, int figurinaId);
        Task<List<Wishlist>> GetWishlist(string userId);
        Task StergeDinWishlist(int id);
        bool ExistaInWishlist(string userId, int figurinaId);
    }
}