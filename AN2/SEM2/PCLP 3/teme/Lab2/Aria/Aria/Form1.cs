using System;
using System.Windows.Forms;

namespace Aria
{
    public partial class Form1 : Form
    {
        double lenAr = 0;
        double widAr = 0;
        double res = 0;
        int counter = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void textGetData(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            double number = 0;
            if (double.TryParse(tb.Text, out double result))
            {
                number = Math.Abs(result);
            }
            else return;

            if (tb.Name == "textLen")
            {
                lenAr = number;
            }
            else if (tb.Name == "textWid") 
            {
                widAr = number;
            } else
            {
                labelRes.Text = "You did someting wrong...";
            }
        }
        private void buttonCalc_Click(object sender, EventArgs e)
        {
            res = lenAr * widAr;

            if (res <= 0)
            {
                if(counter <= 10)
                {
                    labelRes.Text = "How about you insert good numbers?";
                }
                else if(counter <= 20)
                {
                    labelRes.Text = "Stop please.";
                }
                else
                {
                    labelRes.Text = "You like to be annoying...";
                }

                counter++;
                return;
            }

            counter = 0;
            if (lenAr == widAr)
            {
                labelRes.Text = "The area of the square is: " + res.ToString();
            }
            else
            {
                labelRes.Text = "The area of the rectangle is: " + res.ToString();
            }
        }
    }
}
