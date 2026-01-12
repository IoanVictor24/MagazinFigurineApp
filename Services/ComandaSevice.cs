using MagazinFigurineApp.Models;
using MagazinFigurineApp.Repositories.Interfaces;
using MagazinFigurineApp.Services.Intefaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagazinFigurineApp.Services
{
    public class ComandaService : IComandaService
    {
        private readonly IComandaRepository _comandaRepository;
        private readonly ICosRepository _cosRepository;

        public ComandaService(IComandaRepository comandaRepository, ICosRepository cosRepository)
        {
            _comandaRepository = comandaRepository;
            _cosRepository = cosRepository;
        }

        public async Task CreazaComanda(string userId, Comanda dateLivrare)
        {
            // 1. Obținem produsele din coș
            var produseCos = await _cosRepository.GetCosByUserId(userId);
            var subtotal = await _cosRepository.CalculeazaTotal(userId);

            if (produseCos == null || produseCos.Count == 0) return;

            // 2. Creăm obiectul Comanda
            var comandaNoua = new Comanda
            {
                UtilizatorId = userId,
                DataComanda = DateTime.UtcNow,
                TotalPlata = subtotal + 15, // Adăugăm transportul fix
                Status = "Înregistrată",
                MetodaPlata = "Card Online", // Sau preluat din form dacă ai câmp

                // Datele din formular
                Email = dateLivrare.Email,
                Telefon = dateLivrare.Telefon,
                Adresa = dateLivrare.Adresa,

                // Inițializăm lista de produse din comandă
                ComandaFigurine = new List<ComandaFigurina>()
            };

            // 3. Transformăm produsele din Coș în ComandaFigurina
            foreach (var item in produseCos)
            {
                comandaNoua.ComandaFigurine.Add(new ComandaFigurina
                {
                    FigurinaID = item.FigurinaId, // Atenție la mapping (FigurinaId din Cos -> FigurinaID din ComandaFigurina)
                    Cantitate = item.Cantitate
                });
            }

            // 4. Salvăm comanda completă în baza de date
            await _comandaRepository.CreateComanda(comandaNoua);

            // 5. Golim coșul utilizatorului
            foreach (var item in produseCos)
            {
                await _cosRepository.StergeDinCos(item.Id);
            }
        }
    }
}