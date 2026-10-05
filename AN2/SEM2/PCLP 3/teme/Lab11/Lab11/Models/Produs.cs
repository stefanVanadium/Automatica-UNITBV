using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab11.Models
{
    public class Produs
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Denumire { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Pret { get; set; }
        public int Stoc { get; set; }
        public DateTime DataAdaugarii { get; set; } = DateTime.Now;
        // cheie externă + proprietate de navigare
        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; }
    }
}
