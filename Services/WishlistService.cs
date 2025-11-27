using System.Threading.Tasks;
using System.Collections.Generic;
using MagazinFigurineApp.Models;
using MagazinFigurineApp.Repositories.Interfaces;
using MagazinFigurineApp.Services.Intefaces;

namespace MagazinFigurineApp.Services
{
    public class WishlistService : IWishlistService
    {
        private readonly IWishlistRepository _repository;

        public WishlistService(IWishlistRepository repository)
        {
            _repository = repository;
        }

        public async Task AdaugaInWishlist(string userId, int figurinaId)
        {
            if (!ExistaInWishlist(userId, figurinaId))
            {
                await _repository.AdaugaInWishlist(new Wishlist
                {
                    UtilizatorId = userId,
                    FigurinaId = figurinaId
                });
            }
        }

        public async Task<List<Wishlist>> GetWishlist(string userId)
        {
            return await _repository.GetWishlistByUserId(userId);
        }

        public async Task StergeDinWishlist(int id)
        {
            await _repository.StergeDinWishlist(id);
        }

        public bool ExistaInWishlist(string userId, int figurinaId)
        {
            return _repository.ExistaInWishlist(userId, figurinaId);
        }
    }
}