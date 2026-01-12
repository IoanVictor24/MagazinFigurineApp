using MagazinFigurineApp.Models;

public interface IWishlistRepository
{
    Task AdaugaInWishlist(Wishlist item);
    Task<List<Wishlist>> GetWishlistByUserId(string userId);
    Task StergeDinWishlist(int id);
    bool ExistaInWishlist(string userId, int figurinaId);
}
