using MagazinFigurineApp.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MagazinFigurineApp.Models
{
    public class Cos
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UtilizatorId { get; set; }

        [ForeignKey("Figurina")]
        public int FigurinaId { get; set; }

        public Figurina Figurina { get; set; }

        public int Cantitate { get; set; } = 1;

        [NotMapped]
        public decimal Subtotal => Figurina?.Pret * Cantitate ?? 0;
    }
}