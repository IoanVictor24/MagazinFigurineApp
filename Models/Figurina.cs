using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MagazinFigurineApp.Model;
using MagazinFigurineApp.Models;


namespace MagazinFigurineApp.Models;

public class Figurina
{
    [Key]
    public int FigurinaID { get; set; }
    public string Nume { get; set; }
    public decimal Pret { get; set; }
    public string Trilogie { get; set; }
    public DateTime DataLansare { get; set; }
    public string Descriere { get; set; }
    public string SKU { get; set; }
    public int Stoc { get; set; }
    [ForeignKey(nameof(Producator))]
    public int? ProducatorID { get; set; }
    public Producator? Producator { get; set; }
    public ICollection<Recenzie>? Recenzii { get; set; }
    public ICollection<ComandaFigurina>? ComenziFigurine { get; set; }
    [ForeignKey(nameof(Magazin))]
    public int MagazinID { get; set; }
    public Magazin Magazin { get; set; }
    public byte[]? ImagineFigurina { get; set; }
    [DataType(DataType.Upload)]
    [DisplayName("Imagine")]
    [NotMapped]
    public IFormFile? ImageFile { get; set; }
}


