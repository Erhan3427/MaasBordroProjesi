namespace MaasBordroProjesi
{
    partial class Giris
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Giris));
            lblMetin = new Label();
            npSaat = new NumericUpDown();
            dgvCalisanlar = new DataGridView();
            btnSaat = new Button();
            btnYonetici = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            btnKaydet = new Button();
            txtIsim = new TextBox();
            lblGiris = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            toolTip1 = new ToolTip(components);
            btnGeriDon = new Button();
            ((System.ComponentModel.ISupportInitialize)npSaat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCalisanlar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // lblMetin
            // 
            lblMetin.AutoSize = true;
            lblMetin.Font = new Font("Segoe UI", 10F);
            lblMetin.ForeColor = SystemColors.ButtonHighlight;
            lblMetin.Location = new Point(405, 169);
            lblMetin.Name = "lblMetin";
            lblMetin.Size = new Size(320, 23);
            lblMetin.TabIndex = 15;
            lblMetin.Text = "Yeni çalışanın  aylık çalışma saatini giriniz";
            // 
            // npSaat
            // 
            npSaat.Location = new Point(731, 167);
            npSaat.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            npSaat.Name = "npSaat";
            npSaat.Size = new Size(181, 27);
            npSaat.TabIndex = 9;
            // 
            // dgvCalisanlar
            // 
            dgvCalisanlar.BackgroundColor = Color.FromArgb(44, 62, 80);
            dgvCalisanlar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCalisanlar.Location = new Point(-3, 272);
            dgvCalisanlar.Name = "dgvCalisanlar";
            dgvCalisanlar.ReadOnly = true;
            dgvCalisanlar.RowHeadersWidth = 51;
            dgvCalisanlar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCalisanlar.Size = new Size(929, 182);
            dgvCalisanlar.TabIndex = 18;
            // 
            // btnSaat
            // 
            btnSaat.BackColor = Color.MidnightBlue;
            btnSaat.FlatAppearance.BorderSize = 0;
            btnSaat.FlatStyle = FlatStyle.Flat;
            btnSaat.ForeColor = SystemColors.ButtonHighlight;
            btnSaat.Location = new Point(731, 215);
            btnSaat.Name = "btnSaat";
            btnSaat.Size = new Size(181, 40);
            btnSaat.TabIndex = 19;
            btnSaat.Text = "Hesapla";
            btnSaat.UseVisualStyleBackColor = false;
            btnSaat.Click += button1_Click;
            // 
            // btnYonetici
            // 
            btnYonetici.BackColor = Color.Transparent;
            btnYonetici.FlatAppearance.BorderSize = 0;
            btnYonetici.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 192);
            btnYonetici.FlatStyle = FlatStyle.Flat;
            btnYonetici.ForeColor = SystemColors.ButtonHighlight;
            btnYonetici.Location = new Point(771, 12);
            btnYonetici.Name = "btnYonetici";
            btnYonetici.Size = new Size(141, 47);
            btnYonetici.TabIndex = 20;
            btnYonetici.Text = "Yonetim";
            btnYonetici.UseVisualStyleBackColor = false;
            btnYonetici.Click += btnYönetici_Click;
            // 
            // btnKaydet
            // 
            btnKaydet.BackColor = Color.DarkRed;
            btnKaydet.FlatStyle = FlatStyle.Flat;
            btnKaydet.Location = new Point(343, 245);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(175, 43);
            btnKaydet.TabIndex = 21;
            btnKaydet.Text = "Giriş Yap";
            btnKaydet.UseVisualStyleBackColor = false;
            btnKaydet.Click += button1_Click_1;
            // 
            // txtIsim
            // 
            txtIsim.Location = new Point(296, 197);
            txtIsim.Name = "txtIsim";
            txtIsim.Size = new Size(271, 27);
            txtIsim.TabIndex = 22;
            // 
            // lblGiris
            // 
            lblGiris.AutoSize = true;
            lblGiris.Font = new Font("Segoe UI", 10F);
            lblGiris.ForeColor = SystemColors.ButtonHighlight;
            lblGiris.Location = new Point(296, 157);
            lblGiris.Name = "lblGiris";
            lblGiris.Size = new Size(266, 23);
            lblGiris.TabIndex = 23;
            lblGiris.Text = "Hoşgeldiniz Lütfen İsminizi Giriniz";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-1, -6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(929, 325);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 24;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(-3, 167);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(929, 332);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 25;
            pictureBox2.TabStop = false;
            // 
            // btnGeriDon
            // 
            btnGeriDon.BackColor = Color.Maroon;
            btnGeriDon.FlatAppearance.BorderSize = 0;
            btnGeriDon.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 192);
            btnGeriDon.FlatStyle = FlatStyle.Flat;
            btnGeriDon.ForeColor = SystemColors.ButtonHighlight;
            btnGeriDon.Location = new Point(12, 12);
            btnGeriDon.Name = "btnGeriDon";
            btnGeriDon.Size = new Size(141, 47);
            btnGeriDon.TabIndex = 20;
            btnGeriDon.Text = "Geri Dön";
            btnGeriDon.UseVisualStyleBackColor = false;
            btnGeriDon.Click += btngeriDon_Click;
            // 
            // Giris
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 33, 74);
            ClientSize = new Size(924, 450);
            Controls.Add(lblGiris);
            Controls.Add(txtIsim);
            Controls.Add(btnKaydet);
            Controls.Add(btnGeriDon);
            Controls.Add(btnYonetici);
            Controls.Add(btnSaat);
            Controls.Add(dgvCalisanlar);
            Controls.Add(lblMetin);
            Controls.Add(npSaat);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            KeyPreview = true;
            Name = "Giris";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Giris";
            Load += Giris_Load;
            KeyDown += Giris_KeyDown_1;
            ((System.ComponentModel.ISupportInitialize)npSaat).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCalisanlar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblMetin;
        private NumericUpDown npSaat;
        private DataGridView dgvCalisanlar;
        private Button btnSaat;
        private Button btnYonetici;
        private System.Windows.Forms.Timer timer1;
        private Button btnKaydet;
        private TextBox txtIsim;
        private Label lblGiris;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private ToolTip toolTip1;
        private Button btnGeriDon;
    }
}