namespace Lab7
{
    partial class ImageDownloader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtUrls = new System.Windows.Forms.TextBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.dgvStatus = new System.Windows.Forms.DataGridView();
            this.url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUrls
            // 
            this.txtUrls.Location = new System.Drawing.Point(200, 12);
            this.txtUrls.Multiline = true;
            this.txtUrls.Name = "txtUrls";
            this.txtUrls.Size = new System.Drawing.Size(588, 245);
            this.txtUrls.TabIndex = 0;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(22, 193);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(159, 64);
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // dgvStatus
            // 
            this.dgvStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.url,
            this.Column1});
            this.dgvStatus.Location = new System.Drawing.Point(22, 277);
            this.dgvStatus.Name = "dgvStatus";
            this.dgvStatus.RowHeadersWidth = 62;
            this.dgvStatus.RowTemplate.Height = 28;
            this.dgvStatus.Size = new System.Drawing.Size(766, 255);
            this.dgvStatus.TabIndex = 2;
            // 
            // url
            // 
            this.url.HeaderText = "URLs";
            this.url.MinimumWidth = 8;
            this.url.Name = "url";
            this.url.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Status";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // ImageDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 554);
            this.Controls.Add(this.dgvStatus);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.txtUrls);
            this.Name = "ImageDownloader";
            this.Text = "Image Downloader";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrls;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.DataGridView dgvStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn url;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}

