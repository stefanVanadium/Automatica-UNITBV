using Lab8_1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;

namespace Lab8_1
{
    public partial class Form1 : Form
    {
        private readonly List<Figura> _figuri = new List<Figura>();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cbTipFigura.SelectedIndex = 0;
            lbTotaluri.Text = "-";
        }
        private void btnAdauga_Click(object sender, EventArgs e)
        {
            try
            {
                Figura f = CreeazaFigura();
                _figuri.Add(f);
                lbxFiguri.Items.Add(f);
                pnlDesen.Invalidate();
                CurataCampuri();
            }
            catch (Exception ex)
            when (ex is ArgumentException || ex is FormatException)
            {
                MessageBox.Show(ex.Message, "Date invalide",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnSterge_Click(object sender, EventArgs e)
        {
            var selectate = lbxFiguri.SelectedItems
            .Cast<Figura>().ToList();
            foreach (var fig in selectate)
            {
                _figuri.Remove(fig);
                lbxFiguri.Items.Remove(fig);
            }
            pnlDesen.Invalidate();
        }
        private void btnTotaluri_Click(object sender, EventArgs e)
        {
            if (_figuri.Count == 0)
            {
                lbTotaluri.Text = "Nu exista figuri.";
                return;
            }
            double ariaTotala = _figuri.Sum(f => f.CalculeazaArie());
            double perimetruTotal = _figuri.Sum(f =>
            f.CalculeazaPerimetru());
            lbTotaluri.Text =
            $"Arie totala: {ariaTotala:F2}, " +
            $"Perimetru total: {perimetruTotal:F2}";
        }

        private void btnFiltrare_Click(object sender, EventArgs e)
        {
            if (tbFiltru.Text.Length == 0)
            {
                MessageBox.Show("Valoare de filtrat invalida.",
                "Filtru invalid", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                return;
            } else
            {
                var filtrate = _figuri.Where(f => f.CalculeazaPerimetru() < ParseDouble(tbFiltru.Text, "Filtru"))
                    .Cast<Figura>().ToList();
                foreach (var fig in filtrate)
                {
                    _figuri.Remove(fig);
                    lbxFiguri.Items.Remove(fig);
                }
                pnlDesen.Invalidate();
            }
        }

        private void btnSortare_Click(object sender, EventArgs e)
        {
            _figuri.Sort((f1, f2) => f1.CalculeazaArie().CompareTo(f2.CalculeazaArie()));
            lbxFiguri.Items.Clear();
            foreach (var fig in _figuri)
            {
                lbxFiguri.Items.Add(fig);
            }
            pnlDesen.Invalidate();
        }
        private void btnScalare_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(tbScalare.Text, out double result) || result <= 0)
            {
                MessageBox.Show("Factor de scalare invalid.",
                "Scalare invalida", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                return;
            } else {
                var selectate = lbxFiguri.SelectedItems
                .Cast<Figura>().ToList();
                foreach (var fig in selectate)
                {
                    lbxFiguri.Items.Remove(fig);
                    fig.Scaleaza(result);
                    lbxFiguri.Items.Add(fig);
                }
                pnlDesen.Invalidate();
            }
        }
        private void pnlDesen_Paint(object sender, PaintEventArgs e)
        {
            int x = 10, y = 10, maxH = 0;
            foreach (Figura f in _figuri)
            {
                if (x > pnlDesen.Width - 120)
                {
                    x = 10;
                    y += maxH + 10;
                    maxH = 0;
                }
                // apel polimorfic – fiecare figură își știe desenul
                f.Deseneaza(e.Graphics, new Point(x, y));
                x += 120;
                maxH = Math.Max(maxH, 120);
            }
        }
        private Figura CreeazaFigura()
        {
            string tip = cbTipFigura.SelectedItem?.ToString();
            switch (tip)
            {
                case "Cerc":
                    return new Cerc(tbNume.Text,
                    ParseDouble(tbDim1.Text, "Raza"));
                case "Dreptunghi":
                    return new Dreptunghi(tbNume.Text,
                    ParseDouble(tbDim1.Text, "Lungime"),
                    ParseDouble(tbDim2.Text, "Latime"));
                case "Triunghi":
                    return new Triunghi(tbNume.Text,
                    ParseDouble(tbDim1.Text, "Latura a"),
                    ParseDouble(tbDim2.Text, "Latura b"),
                    ParseDouble(tbDim3.Text, "Latura c"));
                case "Patrat":
                    return new Patrat(tbNume.Text,
                    ParseDouble(tbDim1.Text, "Latura"));
                case "Elipsa":
                    return new Elipsa(tbNume.Text,
                    ParseDouble(tbDim1.Text, "Semi-axa mare"),
                    ParseDouble(tbDim2.Text, "Semi-axa mica"));
                default:
                    throw new ArgumentException(
                    "Tip de figura necunoscut.");
            }
        }
        private static double ParseDouble(string text, string nume)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException(
                $"Valoarea {nume} este obligatorie.");
            if (!double.TryParse(text.Replace(',', '.'),
            NumberStyles.Float,
            CultureInfo.InvariantCulture,
            out double val))
                throw new FormatException(
                $"Valoarea {nume} trebuie sa fie numerica.");
            return val;
        }
        private void CurataCampuri()
        {
            tbNume.Clear();
            tbDim2.Clear();
            tbDim1.Clear();
            tbDim3.Clear();
            tbNume.Focus();
        }
    }
}