using MagazinFigurineApp.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MagazinFigurineApp.Models
{
    public class Utilizator : IdentityUser
    {
        //[Key]
        //public int UtilizatorID { get; set; }
        public string? Nume { get; set; }
        public string? Prenume { get; set; }
        //public string Email { get; set; }
        //public string Telefon { get; set; }
        //public string Parola { get; set; }

        public byte[]? UserImage { get; set; }
        [DataType(DataType.Upload)]
        [DisplayName("Imagine")]
        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        public ICollection<Recenzie> Recenzii { get; set; }
        public ICollection<Comanda> Comenzi { get; set; }
    }
}



