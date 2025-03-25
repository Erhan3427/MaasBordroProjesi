namespace MaasBordroProjesi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtİsim = new TextBox();
            npSaat = new NumericUpDown();
            cmbKıdem = new ComboBox();
            btnKaydet = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dgvCalisanlar = new DataGridView();
            btnGuncelle = new Button();
            btnSil = new Button();
            btnYonetim = new Button();
            cbBonus = new CheckBox();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            lblMesaj = new Label();
            panel2 = new Panel();
            label4 = new Label();
            ıconMenuItem1 = new FontAwesome.Sharp.IconMenuItem();
            ((System.ComponentModel.ISupportInitialize)npSaat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCalisanlar).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // txtİsim
            // 
            txtİsim.Location = new Point(115, 110);
            txtİsim.Name = "txtİsim";
            txtİsim.Size = new Size(181, 27);
            txtİsim.TabIndex = 0;
            // 
            // npSaat
            // 
            npSaat.Location = new Point(115, 154);
            npSaat.Maximum = new decimal(new int[] { 400, 0, 0, 0 });
            npSaat.Name = "npSaat";
            npSaat.Size = new Size(181, 27);
            npSaat.TabIndex = 1;
            // 
            // cmbKıdem
            // 
            cmbKıdem.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKıdem.FlatStyle = FlatStyle.Popup;
            cmbKıdem.FormattingEnabled = true;
            cmbKıdem.Location = new Point(115, 200);
            cmbKıdem.Name = "cmbKıdem";
            cmbKıdem.Size = new Size(181, 28);
            cmbKıdem.TabIndex = 2;
            cmbKıdem.SelectedIndexChanged += cmbKıdem_SelectedIndexChanged;
            // 
            // btnKaydet
            // 
            btnKaydet.BackColor = Color.FromArgb(46, 204, 113);
            btnKaydet.FlatStyle = FlatStyle.Flat;
            btnKaydet.Location = new Point(331, 188);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(150, 40);
            btnKaydet.TabIndex = 3;
            btnKaydet.Text = "Ekle";
            btnKaydet.UseVisualStyleBackColor = false;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(31, 30, 68);
            label1.FlatStyle = FlatStyle.Popup;
            label1.ForeColor = Color.White;
            label1.Location = new Point(5, 114);
            label1.Name = "label1";
            label1.Size = new Size(99, 20);
            label1.TabIndex = 4;
            label1.Text = "Çalışanın ismi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(7, 158);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 4;
            label2.Text = "Calısılan Saat";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(24, 204);
            label3.Name = "label3";
            label3.Size = new Size(56, 20);
            label3.TabIndex = 4;
            label3.Text = "Kıdemi";
            // 
            // dgvCalisanlar
            // 
            dgvCalisanlar.BackgroundColor = Color.FromArgb(44, 62, 80);
            dgvCalisanlar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCalisanlar.Location = new Point(2, 273);
            dgvCalisanlar.Name = "dgvCalisanlar";
            dgvCalisanlar.ReadOnly = true;
            dgvCalisanlar.RowHeadersWidth = 51;
            dgvCalisanlar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCalisanlar.Size = new Size(797, 177);
            dgvCalisanlar.TabIndex = 5;
            // 
            // btnGuncelle
            // 
            btnGuncelle.BackColor = Color.FromArgb(46, 204, 113);
            btnGuncelle.FlatStyle = FlatStyle.Flat;
            btnGuncelle.Location = new Point(487, 188);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(150, 40);
            btnGuncelle.TabIndex = 3;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = false;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // btnSil
            // 
            btnSil.BackColor = Color.FromArgb(231, 76, 60);
            btnSil.FlatAppearance.BorderSize = 0;
            btnSil.FlatStyle = FlatStyle.Flat;
            btnSil.Location = new Point(643, 188);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(150, 40);
            btnSil.TabIndex = 3;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += btnSil_Click;
            // 
            // btnYonetim
            // 
            btnYonetim.BackColor = Color.Maroon;
            btnYonetim.FlatAppearance.BorderSize = 0;
            btnYonetim.FlatAppearance.MouseDownBackColor = Color.IndianRed;
            btnYonetim.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnYonetim.FlatStyle = FlatStyle.Flat;
            btnYonetim.ForeColor = SystemColors.ButtonHighlight;
            btnYonetim.Location = new Point(555, 19);
            btnYonetim.Name = "btnYonetim";
            btnYonetim.Size = new Size(140, 41);
            btnYonetim.TabIndex = 6;
            btnYonetim.Text = "Dosya Oluştur";
            btnYonetim.UseVisualStyleBackColor = false;
            btnYonetim.Click += btnYonetim_Click;
            // 
            // cbBonus
            // 
            cbBonus.AutoSize = true;
            cbBonus.ForeColor = SystemColors.ButtonHighlight;
            cbBonus.Location = new Point(524, 122);
            cbBonus.Name = "cbBonus";
            cbBonus.Size = new Size(71, 24);
            cbBonus.TabIndex = 7;
            cbBonus.Text = "Bonus";
            cbBonus.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(31, 30, 68);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(2, -4);
            panel1.Name = "panel1";
            panel1.Size = new Size(107, 282);
            panel1.TabIndex = 8;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(0, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(107, 108);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // lblMesaj
            // 
            lblMesaj.AutoSize = true;
            lblMesaj.Font = new Font("Segoe UI", 17F);
            lblMesaj.ForeColor = SystemColors.ButtonHighlight;
            lblMesaj.Location = new Point(22, 19);
            lblMesaj.Name = "lblMesaj";
            lblMesaj.Size = new Size(94, 40);
            lblMesaj.TabIndex = 7;
            lblMesaj.Text = "label5";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(31, 30, 68);
            panel2.Controls.Add(lblMesaj);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(btnYonetim);
            panel2.Location = new Point(93, -10);
            panel2.Name = "panel2";
            panel2.Size = new Size(706, 70);
            panel2.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 132);
            label4.Name = "label4";
            label4.Size = new Size(97, 20);
            label4.TabIndex = 4;
            label4.Text = "Calısılan Saat";
            // 
            // ıconMenuItem1
            // 
            ıconMenuItem1.IconChar = FontAwesome.Sharp.IconChar.None;
            ıconMenuItem1.IconColor = Color.Black;
            ıconMenuItem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ıconMenuItem1.Name = "ıconMenuItem1";
            ıconMenuItem1.Size = new Size(32, 19);
            ıconMenuItem1.Text = "ıconMenuItem1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 33, 74);
            ClientSize = new Size(800, 450);
            Controls.Add(cbBonus);
            Controls.Add(dgvCalisanlar);
            Controls.Add(btnSil);
            Controls.Add(btnGuncelle);
            Controls.Add(btnKaydet);
            Controls.Add(cmbKıdem);
            Controls.Add(npSaat);
            Controls.Add(txtİsim);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)npSaat).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCalisanlar).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtİsim;
        private NumericUpDown npSaat;
        private Button btnKaydet;
        private Label label1;
        private Label label2;
        private Label label3;
        private DataGridView dgvCalisanlar;
        public ComboBox cmbKıdem;
        private Button btnGuncelle;
        private Button btnSil;
        private Button btnYonetim;
        private CheckBox cbBonus;
        private Panel panel1;
        private Panel panel2;
        private Label label4;
        private FontAwesome.Sharp.IconMenuItem ıconMenuItem1;
        private Label lblMesaj;
        private PictureBox pictureBox1;
    }
}
