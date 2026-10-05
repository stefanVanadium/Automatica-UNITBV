using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7
{
    public partial class ImageDownloader : Form
    {
        // Instanță unică de HttpClient conform recomandărilor (evită epuizarea socket-urilor)
        private static readonly HttpClient _httpClient = new HttpClient();

        public ImageDownloader()
        {
            InitializeComponent();
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            // 1. Obținere URL-uri și curățare listă
            var urls = txtUrls.Lines
                .Select(line => line.Trim())
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .ToList();

            if (!urls.Any())
            {
                MessageBox.Show("Vă rugăm introduceți cel puțin un URL.");
                return;
            }

            // 2. Alegere folder destinație
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string targetFolder = fbd.SelectedPath;
                    dgvStatus.Rows.Clear();

                    List<Task> downloadTasks = new List<Task>();

                    // 3. Lansare procesări în paralel
                    for (int i = 0; i < urls.Count; i++)
                    {
                        string url = urls[i];
                        // Adăugăm rândul în tabel și obținem indexul
                        int rowIndex = dgvStatus.Rows.Add(url, "În curs");

                        // Lansăm task-ul fără await imediat pentru a permite paralelismul
                        downloadTasks.Add(DownloadImageAsync(url, rowIndex, targetFolder));
                    }

                    // 4. Așteptăm finalizarea tuturor descărcărilor
                    await Task.WhenAll(downloadTasks);
                    MessageBox.Show("Toate operațiunile s-au finalizat!");
                }
            }
        }

        private async Task DownloadImageAsync(string url, int rowIndex, string folder)
        {
            try
            {
                // Descărcăm datele
                byte[] imageData = await _httpClient.GetByteArrayAsync(url);

                // Generăm un nume unic de fișier (GUID sau timestamp)
                string fileName = $"img_{Guid.NewGuid().ToString().Substring(0, 8)}.jpg";
                string fullPath = Path.Combine(folder, fileName);

                // Salvare asincronă pe disc
                using (FileStream sourceStream = new FileStream(fullPath,
                    FileMode.Create, FileAccess.Write, FileShare.None,
                    bufferSize: 4096, useAsync: true))
                {
                    await sourceStream.WriteAsync(imageData, 0, imageData.Length);
                }

                // Actualizare UI - Reușită
                UpdateStatus(rowIndex, "Reușită");
            }
            catch (Exception)
            {
                // Actualizare UI - Eșuată
                UpdateStatus(rowIndex, "Eșuată");
            }
        }

        private void UpdateStatus(int rowIndex, string status)
        {
            // Verificăm dacă este necesar Invoke pentru a evita Cross-thread exception
            if (dgvStatus.InvokeRequired)
            {
                dgvStatus.Invoke(new Action(() => UpdateStatus(rowIndex, status)));
            }
            else
            {
                dgvStatus.Rows[rowIndex].Cells[1].Value = status;
            }
        }
    }
}