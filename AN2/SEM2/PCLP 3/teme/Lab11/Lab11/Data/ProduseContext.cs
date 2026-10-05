using Lab11.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab11.Data
{
    public class ProduseContext : DbContext
    {
        public DbSet<Produs> Produse { get; set; }
        public DbSet<Categorie> Categorii { get; set; }
        protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
            @"Data Source=(LocalDB)\MSSQLLocalDB;" +
            @"Initial Catalog=ProduseDB_EF;" +
            @"Integrated Security=True;Encrypt=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configurare suplimentară prin Fluent API
            modelBuilder.Entity<Produs>()
            .HasOne(p => p.Categorie)
            .WithMany(c => c.Produse)
            .HasForeignKey(p => p.CategorieId)
            .OnDelete(DeleteBehavior.Restrict);
            // date inițiale (seed)
            modelBuilder.Entity<Categorie>().HasData(
            new Categorie { Id = 1, Nume = "Alimentare" },
            new Categorie { Id = 2, Nume = "Electronice" },
            new Categorie { Id = 3, Nume = "Îmbrăcăminte" },
            new Categorie { Id = 4, Nume = "Cărți" }
            );
        }
    }
}
