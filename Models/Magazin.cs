using MagazinFigurineApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




namespace MagazinFigurineApp.Models
{
    public class Magazin
    {
        [Key]
        public int MagazinID { get; set; }
        public string Nume { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string ProgramLucru { get; set; }
        //public ICollection<Admin>? Admini { get; set; }
        public ICollection<Figurina> Figurine { get; set; }
    }
}
