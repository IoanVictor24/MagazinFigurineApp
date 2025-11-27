using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagazinFigurineApp.Models
{
    public class Wishlist
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("Figurina")]
        public int FigurinaId { get; set; }

        public Figurina Figurina { get; set; }
    }
}
