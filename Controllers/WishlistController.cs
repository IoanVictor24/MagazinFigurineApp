using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using MagazinFigurineApp.Models;
using MagazinFigurineApp.Services.Intefaces;

namespace MagazinFigurineApp.Controllers
{
    [Authorize(Roles = "User,Admin")]
    public class WishlistController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IWishlistService _wishlistService;
        private readonly IFigurineService _figurineService;

        public WishlistController(
            IWishlistService wishlistService,
            IFigurineService figurineService)
        {
            _wishlistService = wishlistService;
            _figurineService = figurineService;
        }

        // Afișează wishlist-ul utilizatorului
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var wishlist = await _wishlistService.GetWishlist(userId);
            return View(wishlist);
        }

        // Adaugă o figurină în wishlist
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> Adauga(int figurinaId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var figurina = _figurineService.GetFigurinaById(figurinaId);

            if (figurina == null)
            {
                return NotFound();
            }

            await _wishlistService.AdaugaInWishlist(userId, figurinaId);
            return RedirectToAction(nameof(Index));
        }

        // Șterge o figurină din wishlist
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> Sterge(int id)
        {
            await _wishlistService.StergeDinWishlist(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
