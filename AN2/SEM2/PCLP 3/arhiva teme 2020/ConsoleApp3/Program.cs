using System;
using System.Linq;
using System.Text;


namespace ConsoleApp3
{
    class Program
    {

        public string numere(int n)
        {
            string str = "";
            while (n != 0)
            {
                if (n == 1)
                {
                    str = str + "unu";
                    n = 0;
                }
                else if (n == 2)
                {
                    str = str + "doi";
                    n = 0;
                }
                else if (n == 3)
                {
                    str = str + "trei";
                    n = 0;
                }
                else if (n == 4)
                {
                    str = str + "patru";
                    n = 0;
                }
                else if (n == 5)
                {
                    str = str + "cinci";
                    n = 0;
                }
                else if (n == 6)
                {
                    str = str + "sase";
                    n = 0;
                }
                else if (n == 7)
                {
                    str = str + "sapte";
                    n = 0;
                }
                else if (n == 8)
                {
                    str = str + "opt";
                    n = 0;
                }
                else if (n == 9)
                {
                    str = str + "noua";
                    n = 0;
                }
                else if (n == 10)
                {
                    str = str + "zece";
                    n = 0;
                }
                else if (n == 11)
                {
                    str = str + "unsprezece";
                    n = 0;
                }
                else if (n == 12)
                {
                    str = str + "doisprezece";
                    n = 0;
                }
                else if (n == 13)
                {
                    str = str + "treisprezece";
                    n = 0;
                }
                else if (n == 14)
                {
                    str = str + "paisprezece";
                    n = 0;
                }
                else if (n == 15)
                {
                    str = str + "cincisprezece";
                    n = 0;
                }
                else if (n == 16)
                {
                    str = str + "saisprezece";
                    n = 0;
                }
                else if (n == 17)
                {
                    str = str + "saptesprezece";
                    n = 0;
                }
                else if (n == 18)
                {
                    str = str + "optsprezece";
                    n = 0;
                }
                else if (n == 19)
                {
                    str = str + "nouasprezece";
                    n = 0;
                }
                else if (n == 20)
                {
                    str = str + "douazeci";
                    n = 0;
                }
                else if (n > 20 && n < 30)
                {
                    str = str + "douazeci si ";
                    n = n - 20;
                }
                else if (n == 30)
                {
                    str = str + "treizeci";
                    n = 0;
                }
                else if (n > 30 && n < 40)
                {
                    str = str + "treizeci si ";
                    n = n - 30;
                }
                else if (n == 40)
                {
                    str = str + "patruzeci";
                    n = 0;
                }
                else if (n > 40 && n < 50)
                {
                    str = str + "patruzeci si ";
                    n = n - 40;
                }
                else if (n == 50)
                {
                    str = str + "cincizeci";
                    n = 0;
                }
                else if (n > 50 && n < 60)
                {
                    str = str + "cincizeci si ";
                    n = n - 50;
                }
                else if (n == 60)
                {
                    str = str + "saizeci";
                    n = 0;
                }
                else if (n > 60 && n < 70)
                {
                    str = str + "saizeci si ";
                    n = n - 60;
                }
                else if (n == 70)
                {
                    str = str + "saptezeci";
                    n = 0;
                }
                else if (n > 70 && n < 80)
                {
                    str = str + "saptezeci si ";
                    n = n - 70;
                }
                else if (n == 80)
                {
                    str = str + "optzeci";
                    n = 0;
                }
                else if (n > 80 && n < 90)
                {
                    str = str + "optzeci si ";
                    n = n - 80;
                }
                else if (n == 90)
                {
                    str = str + "nouazeci";
                    n = 0;
                }
                else if (n > 90 && n < 100)
                {
                    str = str + "nouazeci si ";
                    n = n - 90;
                }
                else if (n == 100)
                {
                    str = str + "o suta";
                    n = 0;
                }

            }
            return (str);


            
        }

        public string convert(int n)
        {
            string str = "";
            while (n != 0)
            {
                if (n >= 1 && n < 100)
                {
                    str = str + numere(n);
                    n = 0;
                }
            }
            return (str);
        }
        static void Main(string[] args)
        {


            String str;
            int n;
            Program t = new Program();
            Console.WriteLine("Dati un numar");
            n = int.Parse(Console.ReadLine());
            str = t.convert(n);
            Console.WriteLine(str);
            Console.ReadLine();

        }
    }


}
    
   