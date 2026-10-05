using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab11.Models
{
public class Categorie
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Nume { get; set; }
        public ICollection<Produs> Produse { get; set; }
        = new List<Produs>();
        public override string ToString() => Nume;
    }
}
