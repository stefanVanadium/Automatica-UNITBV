using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace ConsoleThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread threadOne = new Thread(new ThreadStart(Function1));
            Thread threadTwo = new Thread(new ThreadStart(Function2));

            threadOne.Start();
            threadTwo.Start();

            Console.WriteLine("End of Main Thread.");

            Console.ReadLine();
        }
        public static void Function1()
        {
            try
            {
                Stopwatch stop = new Stopwatch();
                stop.Start();
                string file1;
                StreamReader streamR1 = new StreamReader(@"C:\Users\Diana\Desktop\file1.txt");
                file1 = streamR1.ReadToEnd();
                file1 = file1.ToUpper();
                streamR1.Close();
                StreamWriter streamR3 = File.CreateText(@"C:\Users\Diana\Desktop\file1Up.txt");
                streamR3.Write(file1);
                streamR3.Close();

                Console.WriteLine("End of file1Up.txt and Thread1, Time:");
                TimeSpan timeS = stop.Elapsed;
                stop.Stop();
                Console.WriteLine(timeS.Milliseconds.ToString() + "ms");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eroare la deschidere!\n" + ex.Message, "Eroare");
            }
        }

        public static void Function2()
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                string file2;
                StreamReader streamR2 = new StreamReader(@"C:\Users\Diana\Desktop\file2.txt");
                file2 = streamR2.ReadToEnd();
                file2 = file2.ToUpper();
                streamR2.Close();
                StreamWriter streamR4 = File.CreateText(@"C:\Users\Diana\Desktop\file2Up.txt");
                streamR4.Write(file2);
                streamR4.Close();

                Console.WriteLine("End of file2Up.txt and Thread2, Time:");
                TimeSpan timeS = stopwatch.Elapsed;
                stopwatch.Stop();
                Console.WriteLine(timeS.Milliseconds.ToString() + "ms");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eroare la deschidere!\n" + ex.Message, "Eroare");
            }
        }
    }
}
