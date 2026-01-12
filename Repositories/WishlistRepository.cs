using MagazinFigurineApp.Context;
using MagazinFigurineApp.Models;
using Microsoft.EntityFrameworkCore;

public class WishlistRepository : IWishlistRepository
{
    private readonly MagazinFigurineContext _context;
    public WishlistRepository(MagazinFigurineContext context)
    {
        _context = context;
    }

    public async Task AdaugaInWishlist(Wishlist item)
    {
        _context.Wishlisturi.Add(item);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Wishlist>> GetWishlistByUserId(string userId)
    {
        return await _context.Wishlisturi
            .Include(w => w.Figurina)
            .Where(w => w.UserId == userId)
            .ToListAsync();
    }

    public async Task StergeDinWishlist(int id)
    {
        var item = await _context.Wishlisturi.FindAsync(id);
        if (item != null)
        {
            _context.Wishlisturi.Remove(item);
            await _context.SaveChangesAsync();
        }
    }

    public bool ExistaInWishlist(string userId, int figurinaId)
    {
        return _context.Wishlisturi
            .Any(w => w.UserId == userId && w.FigurinaId == figurinaId);
    }
}