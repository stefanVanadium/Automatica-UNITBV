using System;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Lab10.Data;
using Lab10.Models;

namespace Lab10
{
    public partial class Form1 : Form
    {
        private readonly ProdusRepository _repository =
        new ProdusRepository();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                DatabaseInitializer.EnsureCreated();
                IncarcaProduse();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Eroare la conectarea la baza de date: "
                + ex.Message, "Eroare",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        private void IncarcaProduse(string filtru = null)
        {
            var produse = _repository.GetAll(filtru);
            dgvProduse.DataSource = produse;
            FormateazaGrid();
            ActualizeazaTotaluri(produse.Count);
        }
        private void FormateazaGrid()
        {
            if (dgvProduse.Columns.Count == 0) return;
            dgvProduse.Columns["DataAdaugarii"]
            .DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
            dgvProduse.Columns["Pret"].DefaultCellStyle.Format = "F2";
            dgvProduse.Columns["ValoareStoc"]
            .DefaultCellStyle.Format = "F2";
        }
        private void ActualizeazaTotaluri(int numar)
        {
            decimal valoareTotala = _repository.GetValoareTotalaStoc();
            lbTotal.Text = $"Număr produse: {numar} | " +
            $"Valoare totală stoc: {valoareTotala:F2} RON";
        }
        private void btnAdauga_Click(object sender, EventArgs e)
        {
            try
            {
                var p = CitesteProdusDinFormular();
                int idNou = _repository.Add(p);
                MessageBox.Show($"Produs adăugat cu Id = {idNou}.");
                IncarcaProduse(tbCautare.Text);
                CurataCampuri();
            }
            catch (Exception ex)
            when (ex is FormatException || ex is ArgumentException)
            {
                MessageBox.Show(ex.Message, "Date invalide",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Eroare SQL: " + ex.Message,
                "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnModifica_Click(object sender, EventArgs e)
        {
            if (dgvProduse.CurrentRow == null) return;
            try
            {
                var p = CitesteProdusDinFormular();
                p.Id = (int)dgvProduse.CurrentRow.Cells["Id"].Value;
                int afectate = _repository.Update(p);
                if (afectate == 0)
                    MessageBox.Show("Nu a fost modificat niciun rând.");
                IncarcaProduse(tbCautare.Text);
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
            _repository.Delete(id);
            IncarcaProduse(tbCautare.Text);
            CurataCampuri();
        }
        private void btnReincarca_Click(object sender, EventArgs e)
        {
            tbCautare.Clear();
            IncarcaProduse();
        }
        private void tbCautare_TextChanged(object sender, EventArgs e)
        {
            IncarcaProduse(tbCautare.Text);
        }
        private void dgvProduse_SelectionChanged(object sender,
        EventArgs e)
        {
            if (dgvProduse.CurrentRow == null) return;
            tbDenumire.Text = dgvProduse.CurrentRow
            .Cells["Denumire"]
            .Value?.ToString();
            tbPret.Text = dgvProduse.CurrentRow
            .Cells["Pret"].Value?.ToString();
            tbStoc.Text = dgvProduse.CurrentRow
            .Cells["Stoc"].Value?.ToString();
            tbCategorie.Text = dgvProduse.CurrentRow
            .Cells["Categorie"]
            .Value?.ToString();
        }
        private Produs CitesteProdusDinFormular()
        {
            if (string.IsNullOrWhiteSpace(tbDenumire.Text))
                throw new ArgumentException("Denumirea este obligatorie.");
            if (!decimal.TryParse(tbPret.Text.Replace(',', '.'),
            NumberStyles.Number,
            CultureInfo.InvariantCulture, out decimal pret)
            || pret < 0)
                throw new FormatException(
                "Prețul trebuie să fie un număr pozitiv.");
            if (!int.TryParse(tbStoc.Text, out int stoc) || stoc < 0)
                throw new FormatException(
                "Stocul trebuie să fie un întreg nenegativ.");
            return new Produs
            {
                Denumire = tbDenumire.Text.Trim(),
                Pret = pret,
                Stoc = stoc,
                Categorie = string.IsNullOrWhiteSpace(tbCategorie.Text)
            ? null : tbCategorie.Text.Trim()
            };
        }
        private void CurataCampuri()
        {
            tbDenumire.Clear();
            tbPret.Clear();
            tbStoc.Clear();
            tbCategorie.Clear();
            tbDenumire.Focus();
        }

        private void btnVinde_Click(object sender, EventArgs e)
        {
            if (dgvProduse.CurrentRow == null)
            {
                MessageBox.Show("Vă rugăm să selectați un produs din listă.");
                return;
            }

            if (!int.TryParse(tbStoc.Text, out int cantitateVanduta))
            {
                MessageBox.Show("Introduceți o cantitate validă.");
                return;
            }

            int produsId = (int)dgvProduse.CurrentRow.Cells["Id"].Value;
            decimal pretUnitar = (decimal)dgvProduse.CurrentRow.Cells["Pret"].Value;

            using (SqlConnection conn = new SqlConnection(DatabaseInitializer.ConnectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    if (cantitateVanduta <= 0)
                        throw new Exception("Cantitatea trebuie să fie pozitivă! (Simulare Rollback)");

                    string sqlCheck = "SELECT Stoc FROM Produse WHERE Id = @Id";
                    SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn, transaction);
                    cmdCheck.Parameters.AddWithValue("@Id", produsId);
                    int stocDisponibil = (int)cmdCheck.ExecuteScalar();

                    if (stocDisponibil < cantitateVanduta)
                        throw new Exception("Stoc insuficient pentru finalizarea vânzării!");

                    string sqlUpdate = "UPDATE Produse SET Stoc = Stoc - @Cantitate WHERE Id = @Id";
                    SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, conn, transaction);
                    cmdUpdate.Parameters.AddWithValue("@Cantitate", cantitateVanduta);
                    cmdUpdate.Parameters.AddWithValue("@Id", produsId);
                    cmdUpdate.ExecuteNonQuery();

                    string sqlInsert = @"INSERT INTO Vanzari (ProdusId, Cantitate, PretUnitar, DataOra) 
                                 VALUES (@ProdusId, @Cantitate, @Pret, @DataOra)";
                    SqlCommand cmdInsert = new SqlCommand(sqlInsert, conn, transaction);
                    cmdInsert.Parameters.AddWithValue("@ProdusId", produsId);
                    cmdInsert.Parameters.AddWithValue("@Cantitate", cantitateVanduta);
                    cmdInsert.Parameters.AddWithValue("@Pret", pretUnitar);
                    cmdInsert.Parameters.AddWithValue("@DataOra", DateTime.Now);
                    cmdInsert.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Vânzare realizată cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    IncarcaProduse(tbCautare.Text);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Eroare la vânzare: " + ex.Message + "\nTranzacția a fost anulată (Rollback).",
                                    "Eroare Tranzacție", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}