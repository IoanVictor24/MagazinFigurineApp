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
using Microsoft.AspNetCore.Authorization;

namespace MagazinFigurineApp.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class MagazineController : Controller
    {
        private readonly IMagazinService _magazinService;
        public MagazineController(IMagazinService magazinService)
        {
            _magazinService = magazinService;
        }


        // GET: Magazine
        public async Task<IActionResult> Index()
        {
            var magazine = _magazinService.GetAllMagazine();
            return View(magazine);
        }

        // GET: Magazine/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var magazin = await _context.Magazine
        //        .FirstOrDefaultAsync(m => m.MagazinID == id);
        //    if (magazin == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(magazin);
        //}

        // GET: Magazine/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Magazine/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MagazinID,Nume,Adresa,Telefon,Email,ProgramLucru")] Magazin magazin)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(magazin);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            _magazinService.AddMagazin(magazin);
            return RedirectToAction("Index");
        }

        // GET: Magazine/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazin = _magazinService.GetMagazinById(id.Value);
            if (magazin == null)
            {
                return NotFound();
            }
            return View(magazin);
        }

        // POST: Magazine/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MagazinID,Nume,Adresa,Telefon,Email,ProgramLucru")] Magazin magazin)
        {
            if (id != magazin.MagazinID)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(magazin);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!MagazinExists(magazin.MagazinID))
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
            _magazinService.UpdateMagazin(magazin);
            return RedirectToAction("Index");
        }

        // GET: Magazine/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var magazin = _magazinService.GetMagazinById(id.Value);
            if (magazin == null)
            {
                return NotFound();
            }

            return View(magazin);
        }

        // POST: Magazine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _magazinService.DeleteMagazin(id);
            return RedirectToAction("Index");
        }

        //private bool MagazinExists(int id)
        //{
        //    return _context.Magazine.Any(e => e.MagazinID == id);
        //}
    }
}
