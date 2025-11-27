using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MagazinFigurineApp.Context;
using MagazinFigurineApp.Model;
using MagazinFigurineApp.Services.Intefaces;
using Microsoft.AspNetCore.Authorization;

namespace MagazinFigurineApp.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ProducatoriController : Controller
    {
        private readonly IProducatorService _producatorService;

        public ProducatoriController(IProducatorService producatorService)
        {
            _producatorService = producatorService;
        }

        // GET: Producatori
        public async Task<IActionResult> Index()
        {
            var producatori = _producatorService.GetAllProducatori();
            return View(producatori);
        }

        // GET: Producatori/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producator = _producatorService.GetProducatorById(id.Value);
            if (producator == null)
            {
                return NotFound();
            }

            return View(producator);
        }

        // GET: Producatori/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producatori/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nume")] Producator producator)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(producator);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            _producatorService.AddProducator(producator);
            return RedirectToAction("Index");
        }

        // GET: Producatori/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producator = _producatorService.GetProducatorById(id.Value);
            if (producator == null)
            {
                return NotFound();
            }
            return View(producator);
        }

        // POST: Producatori/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nume")] Producator producator)
        {
            if (id != producator.ID)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(producator);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!ProducatorExists(producator.ID))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            _producatorService.UpdateProducator(producator);
            return RedirectToAction("Index");
        }

        // GET: Producatori/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producator = _producatorService.GetProducatorById(id.Value);
            if (producator == null)
            {
                return NotFound();
            }

            return View(producator);
        }

        // POST: Producatori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _producatorService.DeleteProducator(id);
            return RedirectToAction("Index");
        }

        //private bool ProducatorExists(int id)
        //{
        //    return _context.Producatori.Any(e => e.ID == id);
        //}
    }
}
