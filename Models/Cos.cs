using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagazinFigurineApp.Models
{
    public class Cos
    {
        [Key]
        public int CosID { get; set; }

        public string UtilizatorId { get; set; }

        // Sincronizat: 'Id' cu d mic
        public int FigurinaId { get; set; }

        public int Cantitate { get; set; }

        [ForeignKey("FigurinaId")]
        public virtual Figurina Figurina { get; set; }
    }
}