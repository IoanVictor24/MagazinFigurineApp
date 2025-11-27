using MagazinFigurineApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MagazinFigurineApp.Models
{
    public class Recenzie
    {
        [Key]
        public int RecenzieID { get; set; }
        public int Rating { get; set; }
        public DateTime DataRecenzie { get; set; }
        public string Comentariu { get; set; }
        [ForeignKey(nameof(Utilizator))]
        public string UtilizatorID { get; set; }
        public virtual Utilizator Utilizator { get; set; }
        [ForeignKey(nameof(Figurina))]
        public int FigurinaID { get; set; }
        public Figurina Figurina { get; set; }
    }
}


