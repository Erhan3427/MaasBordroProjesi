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
            btnYönetici = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            btnKaydet = new Button();
            txtİsim = new TextBox();
            lblGiris = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)npSaat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCalisanlar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblMetin
            // 
            lblMetin.AutoSize = true;
            lblMetin.Font = new Font("Segoe UI", 10F);
            lblMetin.ForeColor = SystemColors.ButtonHighlight;
            lblMetin.Location = new Point(398, 171);
            lblMetin.Name = "lblMetin";
            lblMetin.Size = new Size(316, 23);
            lblMetin.TabIndex = 15;
            lblMetin.Text = "Yeni Çalışanın bu ay Çalıştığı saati giriniz";
            // 
            // npSaat
            // 
            npSaat.Location = new Point(731, 167);
            npSaat.Maximum = new decimal(new int[] { 400, 0, 0, 0 });
            npSaat.Name = "npSaat";
            npSaat.Size = new Size(181, 27);
            npSaat.TabIndex = 9;
            // 
            // dgvCalisanlar
            // 
            dgvCalisanlar.BackgroundColor = Color.FromArgb(44, 62, 80);
            dgvCalisanlar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCalisanlar.Location = new Point(-3, 269);
            dgvCalisanlar.Name = "dgvCalisanlar";
            dgvCalisanlar.ReadOnly = true;
            dgvCalisanlar.RowHeadersWidth = 51;
            dgvCalisanlar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCalisanlar.Size = new Size(929, 182);
            dgvCalisanlar.TabIndex = 18;
            // 
            // btnSaat
            // 
            btnSaat.BackColor = Color.FromArgb(0, 86, 179);
            btnSaat.FlatAppearance.BorderSize = 0;
            btnSaat.FlatStyle = FlatStyle.Flat;
            btnSaat.Location = new Point(731, 215);
            btnSaat.Name = "btnSaat";
            btnSaat.Size = new Size(181, 40);
            btnSaat.TabIndex = 19;
            btnSaat.Text = "Hesapla";
            btnSaat.UseVisualStyleBackColor = false;
            btnSaat.Click += button1_Click;
            // 
            // btnYönetici
            // 
            btnYönetici.BackColor = Color.Transparent;
            btnYönetici.FlatAppearance.BorderSize = 0;
            btnYönetici.FlatStyle = FlatStyle.Flat;
            btnYönetici.ForeColor = SystemColors.ButtonHighlight;
            btnYönetici.Location = new Point(771, 12);
            btnYönetici.Name = "btnYönetici";
            btnYönetici.Size = new Size(141, 47);
            btnYönetici.TabIndex = 20;
            btnYönetici.Text = "Yönetim";
            btnYönetici.UseVisualStyleBackColor = false;
            btnYönetici.Click += btnYönetici_Click;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(338, 223);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(175, 43);
            btnKaydet.TabIndex = 21;
            btnKaydet.Text = "Giriş Yap";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += button1_Click_1;
            // 
            // txtİsim
            // 
            txtİsim.Location = new Point(291, 175);
            txtİsim.Name = "txtİsim";
            txtİsim.Size = new Size(271, 27);
            txtİsim.TabIndex = 22;
            // 
            // lblGiris
            // 
            lblGiris.AutoSize = true;
            lblGiris.Font = new Font("Segoe UI", 10F);
            lblGiris.ForeColor = SystemColors.ButtonHighlight;
            lblGiris.Location = new Point(291, 135);
            lblGiris.Name = "lblGiris";
            lblGiris.Size = new Size(266, 23);
            lblGiris.TabIndex = 23;
            lblGiris.Text = "Hoşgeldiniz Lütfen İsminizi Giriniz";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-3, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(929, 325);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 24;
            pictureBox1.TabStop = false;
            // 
            // Giris
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 33, 74);
            ClientSize = new Size(924, 450);
            Controls.Add(lblGiris);
            Controls.Add(txtİsim);
            Controls.Add(btnKaydet);
            Controls.Add(btnYönetici);
            Controls.Add(btnSaat);
            Controls.Add(dgvCalisanlar);
            Controls.Add(lblMetin);
            Controls.Add(npSaat);
            Controls.Add(pictureBox1);
            Name = "Giris";
            Text = "Giriş";
            Load += Giriş_Load;
            ((System.ComponentModel.ISupportInitialize)npSaat).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCalisanlar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblMetin;
        private NumericUpDown npSaat;
        private DataGridView dgvCalisanlar;
        private Button btnSaat;
        private Button btnYönetici;
        private System.Windows.Forms.Timer timer1;
        private Button btnKaydet;
        private TextBox txtİsim;
        private Label lblGiris;
        private PictureBox pictureBox1;
    }
}