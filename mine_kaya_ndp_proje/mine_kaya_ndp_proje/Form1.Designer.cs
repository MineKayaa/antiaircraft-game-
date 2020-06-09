namespace mine_kaya_ndp_proje
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
            this.components = new System.ComponentModel.Container();
            this.mermi_zaman = new System.Windows.Forms.Timer(this.components);
            this.dusman_zaman = new System.Windows.Forms.Timer(this.components);
            this.ucak = new System.Windows.Forms.PictureBox();
            this.dusman_haraket_ettir = new System.Windows.Forms.Timer(this.components);
            this.mermi_dusman_carpisdimi = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ucak)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mermi_zaman
            // 
            this.mermi_zaman.Tick += new System.EventHandler(this.mermi_zaman_Tick);
            // 
            // dusman_zaman
            // 
            this.dusman_zaman.Tick += new System.EventHandler(this.dusman_zaman_Tick);
            // 
            // ucak
            // 
            this.ucak.Image = global::mine_kaya_ndp_proje.Properties.Resources.Plane_Green;
            this.ucak.Location = new System.Drawing.Point(246, 413);
            this.ucak.Name = "ucak";
            this.ucak.Size = new System.Drawing.Size(80, 45);
            this.ucak.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ucak.TabIndex = 0;
            this.ucak.TabStop = false;
            // 
            // dusman_haraket_ettir
            // 
            this.dusman_haraket_ettir.Tick += new System.EventHandler(this.dusman_haraket_ettir_Tick);
            // 
            // mermi_dusman_carpisdimi
            // 
            this.mermi_dusman_carpisdimi.Tick += new System.EventHandler(this.mermi_dusman_carpisdimi_Tick);
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(586, 63);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Oyunu başlatmak için ENTER tuşuna basınız.\r\nUçaksavarı haraket ettirmek için SAĞ/" +
    "SOL YÖN TUŞLARINI kullanın.\r\nAteş etmek için BOŞLUK tuşuna basınız.\r\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ucak);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ucak)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ucak;
        private System.Windows.Forms.Timer mermi_zaman;
        private System.Windows.Forms.Timer dusman_zaman;
        private System.Windows.Forms.Timer dusman_haraket_ettir;
        private System.Windows.Forms.Timer mermi_dusman_carpisdimi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}

