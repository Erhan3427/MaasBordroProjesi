namespace MaasBordroProjesi
{
    partial class YoneticiPersonel
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
            btnHepsi = new Button();
            btnCalisan = new Button();
            cmbYcalisan = new ComboBox();
            label1 = new Label();
            lsvtRapor = new ListView();
            btnCalisaniGoster = new Button();
            btnAzCalisan = new Button();
            richTextBox1 = new RichTextBox();
            btnPDF = new Button();
            toolTip1 = new ToolTip(components);
            btnGeriDon = new Button();
            btnAzCalisanlarGoster = new Button();
            btnAzCalisanPdf = new Button();
            btnCikis = new Button();
            SuspendLayout();
            // 
            // btnHepsi
            // 
            btnHepsi.BackColor = Color.FromArgb(176, 176, 176);
            btnHepsi.FlatStyle = FlatStyle.Flat;
            btnHepsi.Font = new Font("Segoe UI", 9F);
            btnHepsi.Location = new Point(12, 377);
            btnHepsi.Name = "btnHepsi";
            btnHepsi.Size = new Size(280, 61);
            btnHepsi.TabIndex = 0;
            btnHepsi.Text = "Tüm çalışanların bordrosunu oluştur";
            btnHepsi.UseVisualStyleBackColor = false;
            btnHepsi.Click += btnHepsi_Click;
            // 
            // btnCalisan
            // 
            btnCalisan.BackColor = Color.FromArgb(176, 176, 176);
            btnCalisan.FlatStyle = FlatStyle.Flat;
            btnCalisan.Font = new Font("Segoe UI", 9F);
            btnCalisan.Location = new Point(298, 377);
            btnCalisan.Name = "btnCalisan";
            btnCalisan.Size = new Size(303, 61);
            btnCalisan.TabIndex = 0;
            btnCalisan.Text = "Seçili çalışanın bordrosunu oluştur";
            btnCalisan.UseVisualStyleBackColor = false;
            btnCalisan.Click += btnCalisan_Click;
            // 
            // cmbYcalisan
            // 
            cmbYcalisan.FlatStyle = FlatStyle.Popup;
            cmbYcalisan.FormattingEnabled = true;
            cmbYcalisan.Location = new Point(12, 133);
            cmbYcalisan.Name = "cmbYcalisan";
            cmbYcalisan.Size = new Size(259, 28);
            cmbYcalisan.TabIndex = 1;
            cmbYcalisan.SelectedIndexChanged += cmbYcalisan_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(12, 95);
            label1.Name = "label1";
            label1.Size = new Size(108, 20);
            label1.TabIndex = 2;
            label1.Text = "Çalışanı seçiniz";
            // 
            // lsvtRapor
            // 
            lsvtRapor.BackColor = Color.Silver;
            lsvtRapor.Location = new Point(-3, 180);
            lsvtRapor.Name = "lsvtRapor";
            lsvtRapor.Size = new Size(905, 191);
            lsvtRapor.TabIndex = 3;
            lsvtRapor.UseCompatibleStateImageBehavior = false;
            lsvtRapor.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // btnCalisaniGoster
            // 
            btnCalisaniGoster.BackColor = Color.FromArgb(176, 176, 176);
            btnCalisaniGoster.FlatAppearance.BorderSize = 0;
            btnCalisaniGoster.FlatStyle = FlatStyle.Flat;
            btnCalisaniGoster.Location = new Point(308, 131);
            btnCalisaniGoster.Name = "btnCalisaniGoster";
            btnCalisaniGoster.Size = new Size(155, 40);
            btnCalisaniGoster.TabIndex = 4;
            btnCalisaniGoster.Text = "Çalışanı Göster";
            btnCalisaniGoster.UseVisualStyleBackColor = false;
            btnCalisaniGoster.Click += btnCalisaniGoster_Click;
            // 
            // btnAzCalisan
            // 
            btnAzCalisan.BackColor = Color.FromArgb(176, 176, 176);
            btnAzCalisan.FlatStyle = FlatStyle.Flat;
            btnAzCalisan.Location = new Point(607, 377);
            btnAzCalisan.Name = "btnAzCalisan";
            btnAzCalisan.Size = new Size(285, 61);
            btnAzCalisan.TabIndex = 0;
            btnAzCalisan.Text = "Az çalışanların listesini oluştur";
            btnAzCalisan.UseVisualStyleBackColor = false;
            btnAzCalisan.Click += btnAzCalisan_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.FromArgb(34, 33, 74);
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Font = new Font("Constantia", 13.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            richTextBox1.ForeColor = SystemColors.Window;
            richTextBox1.Location = new Point(488, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox1.Size = new Size(238, 154);
            richTextBox1.TabIndex = 5;
            richTextBox1.Text = "  ╔══════════════════╗\n  ║   MAAS  ══╗      ║\n  ║           ║      ║\n  ║   BORDRO  ╚══    ║\n  ╚══════════════════╝\n\n\n";
            // 
            // btnPDF
            // 
            btnPDF.BackColor = Color.FromArgb(176, 176, 176);
            btnPDF.FlatAppearance.BorderSize = 0;
            btnPDF.FlatStyle = FlatStyle.Flat;
            btnPDF.Location = new Point(12, 12);
            btnPDF.Name = "btnPDF";
            btnPDF.Size = new Size(210, 51);
            btnPDF.TabIndex = 4;
            btnPDF.Text = "Tüm çalışanların PDF oluştur";
            btnPDF.UseVisualStyleBackColor = false;
            btnPDF.Click += btnPdf_Click;
            // 
            // btnGeriDon
            // 
            btnGeriDon.BackColor = Color.Maroon;
            btnGeriDon.FlatAppearance.BorderSize = 0;
            btnGeriDon.FlatStyle = FlatStyle.Flat;
            btnGeriDon.Location = new Point(737, 12);
            btnGeriDon.Name = "btnGeriDon";
            btnGeriDon.Size = new Size(155, 40);
            btnGeriDon.TabIndex = 4;
            btnGeriDon.Text = "Geri Dön";
            btnGeriDon.UseVisualStyleBackColor = false;
            btnGeriDon.Click += btnGeriDon_Click;
            // 
            // btnAzCalisanlarGoster
            // 
            btnAzCalisanlarGoster.BackColor = Color.FromArgb(176, 176, 176);
            btnAzCalisanlarGoster.FlatAppearance.BorderSize = 0;
            btnAzCalisanlarGoster.FlatStyle = FlatStyle.Flat;
            btnAzCalisanlarGoster.Location = new Point(308, 85);
            btnAzCalisanlarGoster.Name = "btnAzCalisanlarGoster";
            btnAzCalisanlarGoster.Size = new Size(155, 40);
            btnAzCalisanlarGoster.TabIndex = 4;
            btnAzCalisanlarGoster.Text = "Az Çalışanları Listele";
            btnAzCalisanlarGoster.UseVisualStyleBackColor = false;
            btnAzCalisanlarGoster.Click += btnAzCalisanlarGoster_Click;
            // 
            // btnAzCalisanPdf
            // 
            btnAzCalisanPdf.BackColor = Color.FromArgb(176, 176, 176);
            btnAzCalisanPdf.FlatAppearance.BorderSize = 0;
            btnAzCalisanPdf.FlatStyle = FlatStyle.Flat;
            btnAzCalisanPdf.Location = new Point(228, 12);
            btnAzCalisanPdf.Name = "btnAzCalisanPdf";
            btnAzCalisanPdf.Size = new Size(210, 51);
            btnAzCalisanPdf.TabIndex = 4;
            btnAzCalisanPdf.Text = "Az çalışanların PDF oluştur";
            btnAzCalisanPdf.UseVisualStyleBackColor = false;
            btnAzCalisanPdf.Click += btnAzCalisanPdf_Click;
            // 
            // btnCikis
            // 
            btnCikis.BackColor = Color.Maroon;
            btnCikis.FlatAppearance.BorderSize = 0;
            btnCikis.FlatStyle = FlatStyle.Flat;
            btnCikis.Location = new Point(737, 121);
            btnCikis.Name = "btnCikis";
            btnCikis.Size = new Size(155, 40);
            btnCikis.TabIndex = 4;
            btnCikis.Text = "Çıkış";
            btnCikis.UseVisualStyleBackColor = false;
            btnCikis.Click += btnCikis_Click;
            // 
            // YoneticiPersonel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 33, 74);
            ClientSize = new Size(904, 450);
            Controls.Add(btnAzCalisanPdf);
            Controls.Add(btnPDF);
            Controls.Add(btnCikis);
            Controls.Add(btnGeriDon);
            Controls.Add(btnAzCalisanlarGoster);
            Controls.Add(btnCalisaniGoster);
            Controls.Add(lsvtRapor);
            Controls.Add(label1);
            Controls.Add(cmbYcalisan);
            Controls.Add(btnCalisan);
            Controls.Add(btnAzCalisan);
            Controls.Add(btnHepsi);
            Controls.Add(richTextBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            KeyPreview = true;
            Name = "YoneticiPersonel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Yonetici";
            Load += Yonetici_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnHepsi;
        private Button btnCalisan;
        private ComboBox cmbYcalisan;
        private Label label1;
        private ListView lsvtRapor;
        private Button btnCalisaniGoster;
        private Button btnAzCalisan;
        private RichTextBox richTextBox1;
        private Button btnPDF;
        private ToolTip toolTip1;
        private Button btnGeriDon;
        private Button btnAzCalisanlarGoster;
        private Button btnAzCalisanPdf;
        private Button btnCikis;
    }
}