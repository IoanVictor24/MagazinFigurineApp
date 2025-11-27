using MagazinFigurineApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MagazinFigurineApp.Models
{
    public class Comanda
    {
        [Key]
        public int ComandaID { get; set; }
        //public int UtilizatorID { get; set; }
        public DateTime DataComanda { get; set; }
        public decimal TotalPlata { get; set; }
        public string MetodaPlata { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Adresa { get; set; }

        // Navigation properties
        [ForeignKey(nameof(Utilizator))]
        public string UtilizatorId { get; set; }
        public virtual Utilizator Utilizator { get; set; }
        public ICollection<ComandaFigurina> ComandaFigurine { get; set; }
    }
}


