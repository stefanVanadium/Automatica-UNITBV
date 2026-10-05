using L07.db.daos;
using L07.db.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L07
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            List<Highscore> lista = HighscoresDAO.findAll();

            foreach(Highscore hs in lista)
            {
                listBox1.Items.Add(hs);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Highscore hs = new Highscore();

            hs.Gamer = textBox1.Text;
            hs.Hscore = int.Parse(textBox2.Text);

            HighscoresDAO.insert(hs);

            textBox1.Text = "";
            textBox2.Text = "";

            button1_Click(this, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Highscore hs = new Highscore();

            hs.Id =listBox1.Items.Count - listBox1.SelectedIndex;

            HighscoresDAO.remove(hs);

            button1_Click(this, null);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count>0)
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
                button6.Enabled = false;
                String rand = Convert.ToString(listBox1.SelectedItem);
                string gamer;
                string score;
                score = rand.Substring(rand.IndexOf("\"")+1,rand.LastIndexOf("\"")-rand.IndexOf("\"")-1);
                gamer = rand.Substring(rand.LastIndexOf(":")+2, rand.LastIndexOf(" ")-rand.LastIndexOf(":")-2);
                textBox3.Text = gamer;
                textBox4.Text = score;
            }
        }
        Highscore hmod = new Highscore();
        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            button6.Enabled = true;
            textBox3.Text = "";
            textBox4.Text = "";
            hmod.Id = listBox1.Items.Count - listBox1.SelectedIndex;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            hmod.Gamer = textBox4.Text;
            hmod.Hscore = int.Parse(textBox3.Text);

            Highscore hs = new Highscore();
            hs.Id= listBox1.Items.Count - listBox1.SelectedIndex;
            hs.Gamer = textBox4.Text;
            hs.Hscore = int.Parse(textBox3.Text);


            HighscoresDAO.modify(hs);

            button1_Click(this, null);
            button4_Click(this, null);
        }
    }
}
