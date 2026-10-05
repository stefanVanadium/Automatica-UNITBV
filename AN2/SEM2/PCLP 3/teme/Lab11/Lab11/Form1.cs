using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Lab11.Data;
using Lab11.Models;

namespace Lab11
{
    public partial class Form1 : Form
    {
        private readonly ProduseContext _context = new ProduseContext();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                _context.Database.EnsureCreated();
                IncarcaCategorii();
                IncarcaProduse();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la inițializare: " + ex.Message,
                "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form1_FormClosing(object sender,
        FormClosingEventArgs e)
        {
            _context.Dispose();
        }
        private void IncarcaCategorii()
        {
            var categorii = _context.Categorii
            .OrderBy(c => c.Nume)
            .ToList();
            // combo pentru editare
            cbCategorie.DataSource = categorii;
            cbCategorie.DisplayMember = "Nume";
            cbCategorie.ValueMember = "Id";
            // combo pentru filtru (cu opțiune Toate)
            var pentruFiltru =
            new System.Collections.Generic.List<Categorie>
            {
            new Categorie { Id = 0, Nume = "(Toate categoriile)" }
            };
            pentruFiltru.AddRange(categorii);
            cbFiltruCategorie.DataSource = pentruFiltru;
            cbFiltruCategorie.DisplayMember = "Nume";
            cbFiltruCategorie.ValueMember = "Id";
        }
        private void IncarcaProduse()
        {
            // construim interogarea folosind LINQ
            IQueryable<Produs> query = _context.Produse
            .Include(p => p.Categorie);
            // filtru după denumire
            if (!string.IsNullOrWhiteSpace(tbCautare.Text))
            {
                string filtru = tbCautare.Text;
                query = query.Where(p => p.Denumire.Contains(filtru));
            }
            // filtru după categorie
            if (cbFiltruCategorie.SelectedValue is int idCat && idCat > 0)
            {
                query = query.Where(p => p.CategorieId == idCat);
            }
            var lista = query.OrderBy(p => p.Denumire).ToList();
            // proiecție pentru afișare
            dgvProduse.DataSource = lista.Select(p => new
            {
                p.Id,
                p.Denumire,
                p.Pret,
                p.Stoc,
                Categorie = p.Categorie.Nume,
                ValoareStoc = p.Pret * p.Stoc,
                p.DataAdaugarii
            }).ToList();
            ActualizeazaTotaluri(lista);
        }
        private void ActualizeazaTotaluri(
        System.Collections.Generic.List<Produs> lista)
        {
            decimal total = lista.Sum(p => p.Pret * p.Stoc);
            lbTotal.Text = $"Număr produse: {lista.Count} | " +
            $"Valoare totală: {total:F2} RON";
        }
        private void btnAdauga_Click(object sender, EventArgs e)
        {
            try
            {
                var p = CitesteProdusDinFormular();
                _context.Produse.Add(p);
                _context.SaveChanges();
                IncarcaProduse();
                CurataCampuri();
            }
            catch (Exception ex)
            when (ex is FormatException || ex is ArgumentException)
            {
                MessageBox.Show(ex.Message, "Date invalide",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Eroare la salvare: "
                + ex.InnerException?.Message,
                "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnModifica_Click(object sender, EventArgs e)
        {
            if (dgvProduse.CurrentRow == null) return;
            try
            {
                int id = (int)dgvProduse.CurrentRow.Cells["Id"].Value;
                var p = _context.Produse.Find(id);
                if (p == null) return;
                // modificăm direct obiectul urmărit de context
                p.Denumire = tbDenumire.Text.Trim();
                p.Pret = ParseDecimal(tbPret.Text, "Pret");
                p.Stoc = ParseInt(tbStoc.Text, "Stoc");
                p.CategorieId = (int)cbCategorie.SelectedValue;
                _context.SaveChanges(); // UPDATE generat automat
                IncarcaProduse();
            }
            catch (Exception ex)
            when (ex is FormatException || ex is ArgumentException)
            {
                MessageBox.Show(ex.Message, "Date invalide",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnSterge_Click(object sender, EventArgs e)
        {
            if (dgvProduse.CurrentRow == null) return;
            int id = (int)dgvProduse.CurrentRow.Cells["Id"].Value;
            var confirm = MessageBox.Show(
            $"Ștergeți produsul cu Id = {id}?",
            "Confirmare", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;
            var p = _context.Produse.Find(id);
            if (p != null)
            {
                _context.Produse.Remove(p);
                _context.SaveChanges();
                IncarcaProduse();
                CurataCampuri();
            }
        }
        private void tbCautare_TextChanged(object sender, EventArgs e)
        => IncarcaProduse();
        private void cbFiltruCategorie_Changed(object sender, EventArgs e)
        => IncarcaProduse();
        private void dgvProduse_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProduse.CurrentRow == null) return;
            int id = (int)dgvProduse.CurrentRow.Cells["Id"].Value;
            // reîncărcăm entitatea pentru a obține toate proprietățile
            var p = _context.Produse.Find(id);
            if (p == null) return;
            tbDenumire.Text = p.Denumire;
            tbPret.Text = p.Pret.ToString("F2",
            CultureInfo.InvariantCulture);
            tbStoc.Text = p.Stoc.ToString();
            cbCategorie.SelectedValue = p.CategorieId;
        }
        private Produs CitesteProdusDinFormular()
        {
            if (string.IsNullOrWhiteSpace(tbDenumire.Text))
                throw new ArgumentException("Denumirea este obligatorie.");
            if (cbCategorie.SelectedValue == null)
                throw new ArgumentException("Selectați o categorie.");
            return new Produs
            {
                Denumire = tbDenumire.Text.Trim(),
                Pret = ParseDecimal(tbPret.Text, "Pret"),
                Stoc = ParseInt(tbStoc.Text, "Stoc"),
                CategorieId = (int)cbCategorie.SelectedValue
            };
        }
        private static decimal ParseDecimal(string text, string nume)
        {
            if (!decimal.TryParse(text.Replace(',', '.'),
            NumberStyles.Number,
            CultureInfo.InvariantCulture, out decimal v) || v < 0)
                throw new FormatException(
                $"{nume} trebuie să fie un număr pozitiv.");
            return v;
        }
        private static int ParseInt(string text, string nume)
        {
            if (!int.TryParse(text, out int v) || v < 0)
                throw new FormatException(
                $"{nume} trebuie să fie un întreg nenegativ.");
            return v;
        }
        private void CurataCampuri()
        {
            tbDenumire.Clear();
            tbPret.Clear();
            tbStoc.Clear();
            tbDenumire.Focus();
        }

        private void btnDeschideRapoarte_Click(object sender, EventArgs e)
        {
            using (FormRapoarte frm = new FormRapoarte())
            {
                frm.ShowDialog();
            }
        }
    }
}