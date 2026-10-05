using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Lab9.Exceptions;
using Lab9.Services;

namespace Lab9
{
    public partial class Form1 : Form
    {
        private ContBancar _cont;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _cont = new ContBancar("Titular demo");
            ActualizeazaInterfata();
            tbSuma.Focus();
        }
        private void btnDepune_Click(object sender, EventArgs e)
        {
            try
            {
                decimal suma = CitesteSuma();
                var t = _cont.Depune(suma, tbComentariu.Text);
                lbxTranzactii.Items.Add(t);
                ActualizeazaInterfata();
                CurataCampuri();
            }
            catch (SumaInvalidaException ex) when (ex.SumaPrimita == 0)
            {
                // filtru: tratăm separat cazul zero
                AfiseazaEroare("Suma nu poate fi zero.", ex);
            }
            catch (SumaInvalidaException ex)
            {
                AfiseazaEroare(ex.Message, ex);
            }
            catch (FormatException ex)
            {
                AfiseazaEroare("Suma introdusă nu este un număr valid.",
                ex);
            }
            catch (OverflowException ex)
            {
                AfiseazaEroare("Suma introdusă este prea mare.", ex);
            }
        }
        private void btnRetrage_Click(object sender, EventArgs e)
        {
            try
            {
                decimal suma = CitesteSuma();
                var t = _cont.Retrage(suma, tbComentariu.Text);
                lbxTranzactii.Items.Add(t);
                ActualizeazaInterfata();
                CurataCampuri();
            }
            catch (FondInsuficientException ex)
            {
                AfiseazaEroare(
                $"Fond insuficient (sold: {ex.SoldCurent:F2}).", ex);
            }
            catch (SumaInvalidaException ex)
            {
                AfiseazaEroare(ex.Message, ex);
            }
            catch (LimitaZilnicaDepasitaException ex)
            {
                AfiseazaEroare($"Limita Depasita ({ex.LimitaZilnica:F2} RON). " +
                  $"Suma totala retrasa: {ex.SumaTotalaRetrasaAzi:F2} RON.",
                ex);
            }
            catch (Exception ex)
            {
                // plasă de siguranță: orice excepție neprevăzută
                AfiseazaEroare("Eroare neașteptată: " + ex.Message, ex);
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            _cont.Reseteaza();
            lbxTranzactii.Items.Clear();
            lbxErori.Items.Clear();
            ActualizeazaInterfata();
        }
        private decimal CitesteSuma()
        {
            if (string.IsNullOrWhiteSpace(tbSuma.Text))
                throw new SumaInvalidaException(
                "Completați câmpul Sumă.");
            string text = tbSuma.Text.Trim().Replace(',', '.');
            return decimal.Parse(text,
            NumberStyles.Number,
            CultureInfo.InvariantCulture);
        }
        private void AfiseazaEroare(string mesajUtilizator,
        Exception ex)
        {
            lbxErori.Items.Add(
            $"{DateTime.Now:HH:mm:ss} - {mesajUtilizator}");
            JurnalErori.Scrie(ex);
        }
        private void ActualizeazaInterfata()
        {
            lbSold.Text = $"Sold: {_cont.Sold:F2} RON";
        }
        private void CurataCampuri()
        {
            tbSuma.Clear();
            tbComentariu.Clear();
            tbSuma.Focus();
        }

        private void btnSalvare_Click(object sender, EventArgs e)
        {
            try
            {
                string savePath = "tranzactii.csv";
                string[] lines = new string[lbxTranzactii.Items.Count];
                for (int i = 0; i < lbxTranzactii.Items.Count; i++)
                {
                    lines[i] = lbxTranzactii.Items[i].ToString();
                }
                File.Create(savePath).Close();
                File.WriteAllLines(savePath, lines);
            }
            catch (IOException ex)
            {
                AfiseazaEroare("Eroare la salvarea fișierului.", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                AfiseazaEroare("Acces neautorizat.", ex);
            }
        }

        private void btnIncarca_Click(object sender, EventArgs e)
        {
            try
            {
                string savePath = "tranzactii.csv";
                string[] lines = File.ReadAllLines(savePath);
                lbxTranzactii.Items.Clear();
                foreach (string line in lines)
                {
                    lbxTranzactii.Items.Add(line);
                }
            }
            catch (IOException ex) {
                AfiseazaEroare("Nu s-a gasit fisierul de tranzactii.", ex);
            }
        }
    }
}
