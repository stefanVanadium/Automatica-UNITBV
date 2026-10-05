using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TempConverter
{
    public partial class Form1 : Form
    {
        double temp = 0;
        double res = 0;
        string resultAsString = null;
        bool canConvert = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void textTemp_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textTemp.Text, out double parsed))
            {
                temp = parsed;
                if (resultAsString == null) labelRes.Text = "Type something and convert!";
                else labelRes.Text = resultAsString;
                canConvert = true;
            }
            else if (textTemp.Text != "" && textTemp.Text != "-")
            {
                labelRes.Text = "By typing I mean numbers, you know? Sigh...";
                canConvert = false;
            }
        }

        private void convertButtons_Click(object sender, EventArgs e)
        {
            if (!canConvert) return;
            Button btn = (Button)sender;
            if (btn.Name == "buttonConvFC")
            {
                res = Math.Round((temp - 32) * 5.0 / 9.0 , 2);
                labelRes.Text = res.ToString() + " °C";
            }
            else if (btn.Name == "buttonConvCF")
            {
                res = Math.Round(1.8 * temp + 32);
                labelRes.Text = res.ToString() + " °F";
            } else
            {
                labelRes.Text = "Something is wrong.";
            }

            resultAsString = labelRes.Text;
        }
    }
}
