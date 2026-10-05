namespace Lab7_2
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblTemp = new System.Windows.Forms.Label();
            this.lblHumidity = new System.Windows.Forms.Label();
            this.lblWind = new System.Windows.Forms.Label();
            this.txtLong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.btnGetWeather = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Longitudine:";
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.Location = new System.Drawing.Point(12, 53);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(104, 20);
            this.lblTemp.TabIndex = 0;
            this.lblTemp.Text = "Temperatura:";
            // 
            // lblHumidity
            // 
            this.lblHumidity.AutoSize = true;
            this.lblHumidity.Location = new System.Drawing.Point(12, 100);
            this.lblHumidity.Name = "lblHumidity";
            this.lblHumidity.Size = new System.Drawing.Size(81, 20);
            this.lblHumidity.TabIndex = 0;
            this.lblHumidity.Text = "Umiditate:";
            // 
            // lblWind
            // 
            this.lblWind.AutoSize = true;
            this.lblWind.Location = new System.Drawing.Point(12, 145);
            this.lblWind.Name = "lblWind";
            this.lblWind.Size = new System.Drawing.Size(51, 20);
            this.lblWind.TabIndex = 0;
            this.lblWind.Text = "Vant: ";
            // 
            // txtLong
            // 
            this.txtLong.Location = new System.Drawing.Point(114, 9);
            this.txtLong.Name = "txtLong";
            this.txtLong.Size = new System.Drawing.Size(124, 26);
            this.txtLong.TabIndex = 1;
            this.txtLong.TextChanged += new System.EventHandler(this.txtLong_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Latitudine:";
            // 
            // txtLat
            // 
            this.txtLat.Location = new System.Drawing.Point(336, 9);
            this.txtLat.Name = "txtLat";
            this.txtLat.Size = new System.Drawing.Size(124, 26);
            this.txtLat.TabIndex = 1;
            this.txtLat.TextChanged += new System.EventHandler(this.txtLat_TextChanged);
            // 
            // btnGetWeather
            // 
            this.btnGetWeather.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetWeather.Location = new System.Drawing.Point(346, 85);
            this.btnGetWeather.Name = "btnGetWeather";
            this.btnGetWeather.Size = new System.Drawing.Size(114, 51);
            this.btnGetWeather.TabIndex = 2;
            this.btnGetWeather.Text = "Cauta";
            this.btnGetWeather.UseVisualStyleBackColor = true;
            this.btnGetWeather.Click += new System.EventHandler(this.btnGetWeather_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 187);
            this.Controls.Add(this.btnGetWeather);
            this.Controls.Add(this.txtLat);
            this.Controls.Add(this.txtLong);
            this.Controls.Add(this.lblWind);
            this.Controls.Add(this.lblHumidity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTemp);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Weather App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.Label lblHumidity;
        private System.Windows.Forms.Label lblWind;
        private System.Windows.Forms.TextBox txtLong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLat;
        private System.Windows.Forms.Button btnGetWeather;
    }
}

