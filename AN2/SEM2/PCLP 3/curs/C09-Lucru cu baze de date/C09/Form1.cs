using C09.DAOs;
using C09.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C09
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count<1)
            {
                return;
            }

            ListViewItem lvi = listView1.SelectedItems[0];

            tbId.Text = lvi.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Tranzactie> tranzactii = TranzactiiDao.findAll();

            foreach (Tranzactie tranzactie in tranzactii)
            {
                ListViewItem lvi = new ListViewItem();

                lvi.Text = tranzactie.Id.ToString();
                lvi.SubItems.Add(tranzactie.TipOperatie == "O" ? "-" + tranzactie.Valoare.ToString() : "+" + tranzactie.Valoare.ToString());
                lvi.SubItems.Add(tranzactie.Descriere);
                lvi.SubItems.Add(tranzactie.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));

                listView1.Items.Add(lvi);
            }
        }
    }
}
