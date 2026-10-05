using System;
using System.IO;
namespace Lab9.Services
{
    public static class JurnalErori
    {
        private static readonly string CaleJurnal =
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
        "erori.log");
        public static void Scrie(Exception ex)
        {
            try
            {
                using (var sw = new StreamWriter(CaleJurnal, append: true))
                {
                    sw.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] " +
                    $"{ex.GetType().Name}: {ex.Message}");
                    if (ex.StackTrace != null)
                    {
                        sw.WriteLine(ex.StackTrace);
                    }
                    sw.WriteLine(new string('-', 60));
                }
            }
            catch
            {
                // dacă jurnalizarea eșuează, nu se propagă eroarea
            }
        }
    }
}