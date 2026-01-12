using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using MagazinFigurineApp.Models;
using MagazinFigurineApp.Services.Intefaces;
using System.Threading.Tasks;
using System.Linq;

namespace MagazinFigurineApp.Controllers
{
    [Authorize]
    public class CosController : Controller
    {
        private readonly ICosService _cosService;
        private readonly IFigurineService _figurineService;

        public CosController(ICosService cosService, IFigurineService figurineService)
        {
            _cosService = cosService;
            _figurineService = figurineService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cosItems = await _cosService.GetCos(userId);
            ViewBag.Total = await _cosService.CalculeazaTotal(userId);
            return View(cosItems);
        }

        [HttpPost]
        public async Task<IActionResult> Adauga(int figurinaId, int cantitate = 1)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _cosService.AdaugaInCos(userId, figurinaId, cantitate);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ActualizeazaCantitate(int cosId, int cantitate)
        {
            if (cantitate > 0)
            {
                await _cosService.ActualizeazaCantitate(cosId, cantitate);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Sterge(int id)
        {
            await _cosService.StergeDinCos(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var total = await _cosService.CalculeazaTotal(userId);

            if (total <= 0) return RedirectToAction("Index");

            ViewBag.TotalFinal = total + 15; // Include transport
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProceseazaComanda(Comanda dateComanda)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var produseCos = await _cosService.GetCos(userId);

            // Simulare salvare comandă
            foreach (var item in produseCos)
            {
                await _cosService.StergeDinCos(item.CosID);
            }

            return RedirectToAction("Confirmare");
        }

        [HttpGet]
        public IActionResult Confirmare()
        {
            return View();
        }
    }
}