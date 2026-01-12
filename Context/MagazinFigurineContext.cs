using Microsoft.EntityFrameworkCore;
using MagazinFigurineApp.Models;
using MagazinFigurineApp.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MagazinFigurineApp.Context
{
    public class MagazinFigurineContext : IdentityDbContext<Utilizator>
    {
        internal object Producator;

        public MagazinFigurineContext(DbContextOptions<MagazinFigurineContext> options)
           : base(options)
        {
        }
        public DbSet<Magazin> Magazine { get; set; }
        public DbSet<Figurina> Figurine { get; set; }
        public DbSet<Recenzie> Recenzii { get; set; }
        public DbSet<Comanda> Comenzi { get; set; }
        public DbSet<ComandaFigurina> ComenziFigurine { get; set; }
        //public DbSet<Utilizator> Utilizatori { get; set; }
        //public DbSet<Admin> Admini { get; set; }
        public DbSet<Producator> Producatori { get; set; }
        public DbSet<Wishlist> Wishlisturi { get; set; }
        public DbSet<Cos> Cosuri { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Îi spunem explicit că ProducatorID este cheia străină, 
            // NU DescriereDetaliata
            modelBuilder.Entity<Figurina>()
                .HasOne(f => f.Producator)
                .WithMany(p => p.Figurine) // Asigură-te că în clasa Producator ai ICollection<Figurina> Figurine
                .HasForeignKey(f => f.ProducatorID)
                .IsRequired(false); // Fiind int? (nullable)

            // Forțăm și cheia primară să fie FigurinaID pentru siguranță
            modelBuilder.Entity<Figurina>().HasKey(f => f.FigurinaID);
        
    }
    }
}
