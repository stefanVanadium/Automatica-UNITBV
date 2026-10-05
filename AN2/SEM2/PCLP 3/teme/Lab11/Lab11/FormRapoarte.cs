using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Lab11.Data;
using Lab11.Models;

namespace Lab11
{
    public class FormRapoarte : Form
    {
        private readonly ProduseContext _context = new ProduseContext();

        private DataGridView dgvGrupateCategorie;
        private DataGridView dgvTop5Scumpe;
        private DataGridView dgvProduseRecente;
        private Label lblCategorieTop;
        private TabControl tabControl;

        public FormRapoarte()
        {
            InitializeComponentManual();
        }

        private void InitializeComponentManual()
        {
            this.Text = "Rapoarte Statistice Produse";
            this.Size = new System.Drawing.Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            tabControl = new TabControl { Dock = DockStyle.Fill };

            var tab1 = new TabPage("Stoc pe Categorii");
            dgvGrupateCategorie = new DataGridView { Dock = DockStyle.Fill, AutoGenerateColumns = true, ReadOnly = true, AllowUserToAddRows = false };
            tab1.Controls.Add(dgvGrupateCategorie);

            var tab2 = new TabPage("Top 5 Cele mai Scumpe");
            dgvTop5Scumpe = new DataGridView { Dock = DockStyle.Fill, AutoGenerateColumns = true, ReadOnly = true, AllowUserToAddRows = false };
            tab2.Controls.Add(dgvTop5Scumpe);

            var tab3 = new TabPage("Categoria Populară");
            lblCategorieTop = new Label
            {
                Dock = DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold)
            };
            tab3.Controls.Add(lblCategorieTop);

            var tab4 = new TabPage("Produse Recente (7 zile)");
            dgvProduseRecente = new DataGridView { Dock = DockStyle.Fill, AutoGenerateColumns = true, ReadOnly = true, AllowUserToAddRows = false };
            tab4.Controls.Add(dgvProduseRecente);

            tabControl.TabPages.AddRange(new TabPage[] { tab1, tab2, tab3, tab4 });
            this.Controls.Add(tabControl);

            this.Load += FormRapoarte_Load;
            this.FormClosing += FormRapoarte_FormClosing;
        }

        private void FormRapoarte_Load(object sender, EventArgs e)
        {
            try
            {
                IncarcaRapoarte();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la încărcarea rapoartelor: " + ex.Message,
                    "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IncarcaRapoarte()
        {
            dgvGrupateCategorie.DataSource = _context.Produse
                .GroupBy(p => p.Categorie.Nume)
                .Select(g => new
                {
                    Categorie = g.Key,
                    NumarProduse = g.Count(),
                    ValoareTotalaStoc = g.Sum(p => p.Pret * p.Stoc)
                })
                .ToList();

            dgvTop5Scumpe.DataSource = _context.Produse
                .Include(p => p.Categorie)
                .OrderByDescending(p => p.Pret)
                .Take(5)
                .Select(p => new
                {
                    p.Id,
                    p.Denumire,
                    p.Pret,
                    p.Stoc,
                    Categorie = p.Categorie.Nume
                })
                .ToList();

            var categorieTop = _context.Produse
                .GroupBy(p => p.Categorie.Nume)
                .OrderByDescending(g => g.Count())
                .Select(g => new
                {
                    NumeCategorie = g.Key,
                    TotalProduse = g.Count()
                })
                .FirstOrDefault();

            if (categorieTop != null)
            {
                lblCategorieTop.Text = $"Categoria cu cele mai multe produse este:\n\n" +
                                      $"{categorieTop.NumeCategorie} ({categorieTop.TotalProduse} produse)";
            }
            else
            {
                lblCategorieTop.Text = "Nu există produse în baza de date.";
            }
            DateTime limitaData = DateTime.Now.AddDays(-7);
            dgvProduseRecente.DataSource = _context.Produse
                .Include(p => p.Categorie)
                .Where(p => p.DataAdaugarii >= limitaData)
                .OrderByDescending(p => p.DataAdaugarii)
                .Select(p => new
                {
                    p.Id,
                    p.Denumire,
                    p.Pret,
                    p.DataAdaugarii,
                    Categorie = p.Categorie.Nume
                })
                .ToList();
        }

        private void FormRapoarte_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context.Dispose();
        }
    }
}