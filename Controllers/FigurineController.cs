using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MagazinFigurineApp.Context;
using MagazinFigurineApp.Models;
using MagazinFigurineApp.Services.Intefaces;
using MagazinFigurineApp.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Hosting;

namespace MagazinFigurineApp.Controllers
{
    public class FigurineController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IFigurineService _figurineService;
        private IWebHostEnvironment? hostEnvironment;

        public FigurineController(IFigurineService figurineService)
        {
            _figurineService = figurineService;
            _hostEnvironment = hostEnvironment;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var figurine = _figurineService.GetAllFigurine();
            var reviews = _figurineService.GetAllReviews();
            var producator = _figurineService.GetAllProducatori();
            var magazin = _figurineService.GetAllMagazine();

            return View(figurine);
        }
        [AllowAnonymous] // Permite oricui (chiar și ne-logat) să vadă detaliile produsului
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var figurina = _figurineService.GetFigurinaById(id.Value);

            if (figurina == null)
            {
                return NotFound();
            }

            return View(figurina);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            var figurine = _figurineService.GetAllFigurine();
            var reviews = _figurineService.GetAllReviews();
            var producator = _figurineService.GetAllProducatori();
            var magazin = _figurineService.GetAllMagazine();
            ViewData["ProducatorID"] = new SelectList(producator, "ID", "Nume");
            ViewData["MagazinID"] = new SelectList(magazin, "MagazinID", "Nume");
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FigurinaID,Nume,Pret,Trilogie,DataLansare,Descriere,DescriereDetaliata,PovestePersonaj,SKU,Stoc,ProducatorID,MagazinID,ImageFile")] Figurina figurina)
        {
            if (figurina.ImageFile != null)
            {
                // Stabilim calea folosind _hostEnvironment
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(figurina.ImageFile.FileName);
                string productPath = Path.Combine(wwwRootPath, @"images\figurine");

                // --- SOLUȚIA: Creăm folderul dacă nu există ---
                if (!Directory.Exists(productPath))
                {
                    Directory.CreateDirectory(productPath);
                }

                string fullPath = Path.Combine(productPath, fileName);

                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    await figurina.ImageFile.CopyToAsync(fileStream);
                }

                figurina.ImagineUrl = fileName;
            }

            figurina.DataLansare = figurina.DataLansare.ToUniversalTime();
            _figurineService.AddFigurina(figurina);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FigurinaID,Nume,Pret,Trilogie,DataLansare,Descriere,DescriereDetaliata,PovestePersonaj,SKU,Stoc,ProducatorID,MagazinID,ImagineUrl,ImageFile")] Figurina figurina)
        {
            if (id != figurina.FigurinaID) return NotFound();

            if (figurina.ImageFile != null)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(figurina.ImageFile.FileName);
                string path = Path.Combine(wwwRootPath, @"images\figurine", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await figurina.ImageFile.CopyToAsync(fileStream);
                }
                figurina.ImagineUrl = fileName;
            }

            await _figurineService.UpdateFigurina(figurina);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var figurina = _figurineService.GetFigurinaById(id);
            if (figurina != null)
            {
                _figurineService.DeleteFigurina(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}