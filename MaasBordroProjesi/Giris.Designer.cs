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
            label2 = new Label();
            npSaat = new NumericUpDown();
            dgvCalisanlar = new DataGridView();
            btnSaat = new Button();
            btnYönetici = new Button();
            ((System.ComponentModel.ISupportInitialize)npSaat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCalisanlar).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 88);
            label2.Name = "label2";
            label2.Size = new Size(276, 20);
            label2.TabIndex = 15;
            label2.Text = "Yeni Çalışanın bu ay Çalıştığı saati giriniz";
            // 
            // npSaat
            // 
            npSaat.Location = new Point(318, 86);
            npSaat.Maximum = new decimal(new int[] { 400, 0, 0, 0 });
            npSaat.Name = "npSaat";
            npSaat.Size = new Size(181, 27);
            npSaat.TabIndex = 9;
            // 
            // dgvCalisanlar
            // 
            dgvCalisanlar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCalisanlar.Location = new Point(2, 261);
            dgvCalisanlar.Name = "dgvCalisanlar";
            dgvCalisanlar.ReadOnly = true;
            dgvCalisanlar.RowHeadersWidth = 51;
            dgvCalisanlar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCalisanlar.Size = new Size(786, 177);
            dgvCalisanlar.TabIndex = 18;
            // 
            // btnSaat
            // 
            btnSaat.Location = new Point(318, 134);
            btnSaat.Name = "btnSaat";
            btnSaat.Size = new Size(181, 40);
            btnSaat.TabIndex = 19;
            btnSaat.Text = "Hesapla";
            btnSaat.UseVisualStyleBackColor = true;
            btnSaat.Click += button1_Click;
            // 
            // btnYönetici
            // 
            btnYönetici.Location = new Point(647, 12);
            btnYönetici.Name = "btnYönetici";
            btnYönetici.Size = new Size(141, 47);
            btnYönetici.TabIndex = 20;
            btnYönetici.Text = "Yönetim";
            btnYönetici.UseVisualStyleBackColor = true;
            btnYönetici.Click += btnYönetici_Click;
            // 
            // Giris
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnYönetici);
            Controls.Add(btnSaat);
            Controls.Add(dgvCalisanlar);
            Controls.Add(label2);
            Controls.Add(npSaat);
            Name = "Giris";
            Text = "Giriş";
            Load += Giriş_Load;
            ((System.ComponentModel.ISupportInitialize)npSaat).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCalisanlar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private NumericUpDown npSaat;
        private DataGridView dgvCalisanlar;
        private Button btnSaat;
        private Button btnYönetici;
    }
}