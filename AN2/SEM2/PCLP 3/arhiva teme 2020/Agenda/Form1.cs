using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        static DataSet1 db;
        protected static DataSet1 App
        {
            get
            {
                if (db == null)
                    db = new DataSet1();
                return db;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string fileName = string.Format("{0}//data.dat", Application.StartupPath);
            if (File.Exists(fileName))
                App.Agenda.ReadXml(fileName);
            agendaBindingSource.DataSource = App.Agenda;
            panel1.Enabled = false;
        }

        private void btnNou_Click(object sender, EventArgs e)
        {
            try
            {
                panel1.Enabled = true;
                App.Agenda.AddAgendaRow(App.Agenda.NewAgendaRow());
                agendaBindingSource.MoveLast();
                txtNrTel.Focus();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "Incercati din nou!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                App.Agenda.RejectChanges();
            }
        }

        private void btnSalvare_Click(object sender, EventArgs e)
        {
            try
            {
                agendaBindingSource.EndEdit();
                App.Agenda.AcceptChanges();
                App.Agenda.WriteXml(string.Format("{0}//data.dat", Application.StartupPath));
                panel1.Enabled = false;
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "Incercati din nou!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                App.Agenda.RejectChanges();
            }
           
        }

        private void btnModificare_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            txtNrTel.Focus();
        }

        private void btnAnulare_Click(object sender, EventArgs e)
        {
            agendaBindingSource.ResetBindings(false);
            panel1.Enabled = false;
        }

        private void dataGrid(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Sunteti sigur ca doriti sa stergeti aceasta inregistrare?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    agendaBindingSource.RemoveCurrent();
            }
        }

        private void txtCautare_Key(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (!string.IsNullOrEmpty(txtCautare.Text))
                {
                    var query = from o in App.Agenda
                                where o.Numar_de_telefon == txtCautare.Text || o.Nume_si_prenume.Contains(txtCautare.Text) || o._Adresa_de_e_mail == txtCautare.Text
                                select o;
                    dataGridView1.DataSource = query.ToList();
                }
                else dataGridView1.DataSource = agendaBindingSource;
            }
        }
    }
}
