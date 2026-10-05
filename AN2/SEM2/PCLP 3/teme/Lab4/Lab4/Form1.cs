using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Simulator : Form
    {
        public Simulator()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            lstSimulare.Columns.Clear();
            lstSimulare.Items.Clear();
            lstSimulare.View = View.Details;
            lstSimulare.FullRowSelect = true;
            lstSimulare.GridLines = true;
            lstSimulare.Columns.Add("Luna", 70, HorizontalAlignment.Center);
            lstSimulare.Columns.Add("Sold inițial (lei)", 120,
            HorizontalAlignment.Center);
            lstSimulare.Columns.Add("Depunere (lei)", 110,
            HorizontalAlignment.Center);
            lstSimulare.Columns.Add("Dobândă (lei)", 110,
            HorizontalAlignment.Center);
            lstSimulare.Columns.Add("Sold final (lei)", 120,
            HorizontalAlignment.Center);
            tbSumaInitiala.Focus();
        }
        private void btnSimulare_Click(object sender, EventArgs e)
        {
            // Resetare culori
            tbSumaInitiala.BackColor = Color.White;
            tbDepunereLunara.BackColor = Color.White;
            // Validare sumă inițială
            if (!double.TryParse(tbSumaInitiala.Text, out double sumaInitiala) ||
            sumaInitiala < 0)
            {
                tbSumaInitiala.BackColor = Color.MistyRose;
                MessageBox.Show("Introduceți o sumă inițială validă (număr pozitiv sau zero).");
                tbSumaInitiala.Focus();
                return;
            }
            // Validare depunere lunară
            if (!double.TryParse(tbDepunereLunara.Text,
            out double depunereLunara) ||
            depunereLunara <= 0)
            {
                tbDepunereLunara.BackColor = Color.MistyRose;
                MessageBox.Show("Introduceți o depunere lunară validă (număr pozitiv).");
                tbDepunereLunara.Focus();
                return;
            }
            // Resetare rezultate anterioare
            lstSimulare.Items.Clear();
            // Parametri simulare
            double sold = sumaInitiala;
            double sumaTinta = 10000.0;
            if (double.TryParse(txtSumaTinta.Text, out double sumaParsed) && sumaParsed > sumaInitiala)
            {
                sumaTinta = sumaParsed;
            } else
            {
                MessageBox.Show("Suma tinta nu poate fi mai mica decat suma initiala!");
                return;
            }
            
            double rataDobanzii = 0.006; // 0.6% pe lună
            if (double.TryParse(txtDobanda.Text, out double dobParsed) && dobParsed > 0)
            {
                rataDobanzii = dobParsed / 100;
            }
            else
            {
                MessageBox.Show("Dobanda trebuie sa fie mai mare decat 0!");
                return;
            }
            int luna = 1;
            // Simulare lunară
            while (sold < sumaTinta)
            {
                double soldInitial = sold;
                double dobanda = (soldInitial + depunereLunara) * rataDobanzii;
                double soldFinal = soldInitial + depunereLunara + dobanda;
                ListViewItem item = new ListViewItem(luna.ToString());
                item.SubItems.Add(soldInitial.ToString("F2"));
                item.SubItems.Add(depunereLunara.ToString("F2"));
                item.SubItems.Add(dobanda.ToString("F2"));
                item.SubItems.Add(soldFinal.ToString("F2"));
                lstSimulare.Items.Add(item);
                sold = soldFinal;
                luna++;
            }
            MessageBox.Show(
            $"Depozitul a atins suma de {sold:F2} lei în {luna - 1} luni.",
            "Simulare finalizată",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
            );
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            tbSumaInitiala.Text = "";
            tbDepunereLunara.Text = "";
            tbSumaInitiala.BackColor = Color.White;
            tbDepunereLunara.BackColor = Color.White;
            lstSimulare.Items.Clear();
            tbSumaInitiala.Focus();
        }
    }
}