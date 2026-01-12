using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using MagazinFigurineApp.Models;
using MagazinFigurineApp.Services.Intefaces;

namespace MagazinFigurineApp.Controllers
{
    [Authorize(Roles = "User,Admin")]
    public class CosController : Controller // Specifică namespace-ul corect
    {
        private readonly ICosService _cosService;
        private readonly IFigurineService _figurineService;
        private readonly IComandaService _comandaService;

        public CosController(
            ICosService cosService,
            IFigurineService figurineService,
            IComandaService comandaService)
        {
            _cosService = cosService;
            _figurineService = figurineService;
            _comandaService = comandaService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cos = await _cosService.GetCos(userId);
            ViewBag.Total = await _cosService.CalculeazaTotal(userId);
            return View(cos);
        }

        [Microsoft.AspNetCore.Mvc.HttpPost] // Specifică atributul corect
        public async Task<IActionResult> Adauga(int figurinaId, int cantitate = 1)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var figurina = _figurineService.GetFigurinaById(figurinaId);

            if (figurina == null || cantitate <= 0)
            {
                return NotFound();
            }

            await _cosService.AdaugaInCos(userId, figurinaId, cantitate);
            return RedirectToAction(nameof(Index));
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> ActualizeazaCantitate(int cosId, int cantitate)
        {
            if (cantitate <= 0)
            {
                return BadRequest("Cantitatea trebuie să fie mai mare decât 0.");
            }

            await _cosService.ActualizeazaCantitate(cosId, cantitate);
            return RedirectToAction(nameof(Index));
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
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
            // Validare de bază (dacă ai adnotări în model)
            // if (!ModelState.IsValid) return View("Checkout", dateComanda);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Apelăm serviciul care face toată treaba (Salvare DB + Golire Coș)
            await _comandaService.CreazaComanda(userId, dateComanda);

            return RedirectToAction("Confirmare");
        }

        [HttpGet]
        public IActionResult Confirmare()
        {
            return View();
        }
    }
}