using MagazinFigurineApp.Models;
using System.ComponentModel.DataAnnotations;
namespace MagazinFigurineApp.Model
{
    public class Producator
    {
        [Key]
        public int ID { get; set; } // Cheia primară
        public string Nume { get; set; }
        public ICollection<Figurina>? Figurine { get; set; }
    }
}