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
            ((System.ComponentModel.ISupportInitialize)npSaat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCalisanlar).BeginInit();
            SuspendLayout();
            // 
            // txtİsim
            // 
            txtİsim.Location = new Point(115, 53);
            txtİsim.Name = "txtİsim";
            txtİsim.Size = new Size(181, 27);
            txtİsim.TabIndex = 0;
            // 
            // npSaat
            // 
            npSaat.Location = new Point(115, 126);
            npSaat.Maximum = new decimal(new int[] { 400, 0, 0, 0 });
            npSaat.Name = "npSaat";
            npSaat.Size = new Size(181, 27);
            npSaat.TabIndex = 1;
            npSaat.Leave += npSaat_Leave;
            // 
            // cmbKıdem
            // 
            cmbKıdem.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKıdem.FormattingEnabled = true;
            cmbKıdem.Location = new Point(115, 186);
            cmbKıdem.Name = "cmbKıdem";
            cmbKıdem.Size = new Size(181, 28);
            cmbKıdem.TabIndex = 2;
            cmbKıdem.SelectedIndexChanged += cmbKıdem_SelectedIndexChanged;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(412, 200);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(150, 40);
            btnKaydet.TabIndex = 3;
            btnKaydet.Text = "Ekle";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 60);
            label1.Name = "label1";
            label1.Size = new Size(36, 20);
            label1.TabIndex = 4;
            label1.Text = "isim";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 128);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 4;
            label2.Text = "Calısılan Saat";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 194);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 4;
            label3.Text = "Kıdem";
            // 
            // dgvCalisanlar
            // 
            dgvCalisanlar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCalisanlar.Location = new Point(2, 271);
            dgvCalisanlar.Name = "dgvCalisanlar";
            dgvCalisanlar.ReadOnly = true;
            dgvCalisanlar.RowHeadersWidth = 51;
            dgvCalisanlar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCalisanlar.Size = new Size(786, 177);
            dgvCalisanlar.TabIndex = 5;
            // 
            // btnGuncelle
            // 
            btnGuncelle.Location = new Point(412, 154);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(150, 40);
            btnGuncelle.TabIndex = 3;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = true;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // btnSil
            // 
            btnSil.Location = new Point(412, 108);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(150, 40);
            btnSil.TabIndex = 3;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // btnYonetim
            // 
            btnYonetim.Location = new Point(648, 12);
            btnYonetim.Name = "btnYonetim";
            btnYonetim.Size = new Size(140, 41);
            btnYonetim.TabIndex = 6;
            btnYonetim.Text = "Dosya Oluştur";
            btnYonetim.UseVisualStyleBackColor = true;
            btnYonetim.Click += btnYonetim_Click;
            // 
            // cbBonus
            // 
            cbBonus.AutoSize = true;
            cbBonus.Location = new Point(412, 53);
            cbBonus.Name = "cbBonus";
            cbBonus.Size = new Size(71, 24);
            cbBonus.TabIndex = 7;
            cbBonus.Text = "Bonus";
            cbBonus.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cbBonus);
            Controls.Add(btnYonetim);
            Controls.Add(dgvCalisanlar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSil);
            Controls.Add(btnGuncelle);
            Controls.Add(btnKaydet);
            Controls.Add(cmbKıdem);
            Controls.Add(npSaat);
            Controls.Add(txtİsim);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)npSaat).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCalisanlar).EndInit();
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
    }
}
