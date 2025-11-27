using MagazinFigurineApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MagazinFigurineApp.Models
{
    public class ComandaFigurina
    {
        [Key]
        public int ComandaFigurinaID { get; set; }
        [ForeignKey(nameof(Comanda))]
        public int ComandaID { get; set; }
        public Comanda Comanda { get; set; }
        [ForeignKey(nameof(Figurina))]
        public int FigurinaID { get; set; }
        public Figurina Figurina { get; set; }
        public int Cantitate { get; set; }
    }
}

