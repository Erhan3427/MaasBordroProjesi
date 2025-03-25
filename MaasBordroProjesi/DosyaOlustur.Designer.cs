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
            btnHepsi = new Button();
            btnCalisan = new Button();
            cmbYcalisan = new ComboBox();
            label1 = new Label();
            lsvtRapor = new ListView();
            button1 = new Button();
            btnPdf = new Button();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // btnHepsi
            // 
            btnHepsi.BackColor = Color.FromArgb(176, 176, 176);
            btnHepsi.FlatStyle = FlatStyle.Flat;
            btnHepsi.Font = new Font("Segoe UI", 9F);
            btnHepsi.Location = new Point(12, 377);
            btnHepsi.Name = "btnHepsi";
            btnHepsi.Size = new Size(251, 61);
            btnHepsi.TabIndex = 0;
            btnHepsi.Text = "Tüm Çalışanların bordrosunu oluştur";
            btnHepsi.UseVisualStyleBackColor = false;
            btnHepsi.Click += btnHepsi_Click;
            // 
            // btnCalisan
            // 
            btnCalisan.BackColor = Color.FromArgb(176, 176, 176);
            btnCalisan.FlatStyle = FlatStyle.Flat;
            btnCalisan.Font = new Font("Segoe UI", 9F);
            btnCalisan.Location = new Point(280, 377);
            btnCalisan.Name = "btnCalisan";
            btnCalisan.Size = new Size(251, 61);
            btnCalisan.TabIndex = 0;
            btnCalisan.Text = "Seçili çalışanın bordrosunu oluştur";
            btnCalisan.UseVisualStyleBackColor = false;
            btnCalisan.Click += btnCalisan_Click;
            // 
            // cmbYcalisan
            // 
            cmbYcalisan.FlatStyle = FlatStyle.Popup;
            cmbYcalisan.FormattingEnabled = true;
            cmbYcalisan.Location = new Point(12, 114);
            cmbYcalisan.Name = "cmbYcalisan";
            cmbYcalisan.Size = new Size(259, 28);
            cmbYcalisan.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(12, 76);
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
            lsvtRapor.Size = new Size(806, 191);
            lsvtRapor.TabIndex = 3;
            lsvtRapor.UseCompatibleStateImageBehavior = false;
            lsvtRapor.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(176, 176, 176);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(301, 107);
            button1.Name = "button1";
            button1.Size = new Size(122, 40);
            button1.TabIndex = 4;
            button1.Text = "Çalışanı Göster";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnPdf
            // 
            btnPdf.BackColor = Color.FromArgb(176, 176, 176);
            btnPdf.FlatStyle = FlatStyle.Flat;
            btnPdf.Location = new Point(537, 377);
            btnPdf.Name = "btnPdf";
            btnPdf.Size = new Size(251, 61);
            btnPdf.TabIndex = 0;
            btnPdf.Text = "Tüm çalışanların PDF'ini oluştur";
            btnPdf.UseVisualStyleBackColor = false;
            btnPdf.Click += btnPdf_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.FromArgb(34, 33, 74);
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Font = new Font("Constantia", 13.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            richTextBox1.ForeColor = SystemColors.Window;
            richTextBox1.Location = new Point(505, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox1.Size = new Size(283, 149);
            richTextBox1.TabIndex = 5;
            richTextBox1.Text = "  ╔══════════════════╗\n  ║   MAAS  ══╗      ║\n  ║           ║      ║\n  ║   BORDRO  ╚══    ║\n  ╚══════════════════╝\n\n\n";
            // 
            // YoneticiPersonel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 33, 74);
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBox1);
            Controls.Add(button1);
            Controls.Add(lsvtRapor);
            Controls.Add(label1);
            Controls.Add(cmbYcalisan);
            Controls.Add(btnCalisan);
            Controls.Add(btnPdf);
            Controls.Add(btnHepsi);
            Name = "YoneticiPersonel";
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
        private Button button1;
        private Button btnPdf;
        private RichTextBox richTextBox1;
    }
}