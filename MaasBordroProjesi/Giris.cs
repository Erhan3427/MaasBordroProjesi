using Bordro;
using Bordro.Bordro;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaasBordroProjesi
{

    public partial class Giris : Form
    {
        public static string isim;// Kullanıcı adını saklamak için statik değişken diğer formda kullanılacak
        List<Memur> jsonCalisan = new List<Memur>(); // JSON'dan okunan memur listesi
        List<Personel> tumCalisan = new List<Personel>();// Tüm çalışanların listesi
        Personel personel;
        public Giris()
        {
            InitializeComponent();
            // Başlangıçta bazı kontrolleri gizliyoruz
            lblMetin.Visible = false;
            npSaat.Visible = false;
            btnSaat.Visible = false;
            btnYönetici.Visible = false;
            dgvCalisanlar.Visible = false;
            btngeriDon.Visible = false;

        }

      
        private void Giris_Load(object sender, EventArgs e)
        {
            // DataGridView ayarları
            dgvCalisanlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Sütunların otomatik olarak doldurulması
            dgvCalisanlar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Satırların otomatik olarak doldurulması
            dgvCalisanlar.AutoGenerateColumns = true;
            dgvCalisanlar.DefaultCellStyle.SelectionBackColor = Color.MidnightBlue;


            toolTip1.SetToolTip(btnYönetici, "Yönetim paneline geçiş yapar");
            toolTip1.SetToolTip(btnSaat, "Çalışanın bu ayki çalışma saatini girmenizi ve maaş hesaplamanızı sağlar");
            try
            {
                // JSON'dan memur verilerini oku
                jsonCalisan = DosyaOku.MemurOku();

                foreach (Personel item in jsonCalisan)
                {
                    // saatlik ücreti atıyoruz derece adlarına göre
                    var dereceler = MemurDerecesi.TumDereceler();
                    foreach (var derece in dereceler)
                    {
                        if (item.Derece.DereceAdi == derece.DereceAdi)
                        {
                            item.SaatlikVerilenUcret = derece.SaatlikUcret;
                        }
                        item.MaasAta();
                    }

                    tumCalisan.Add(item);
                    dgvCalisanlar.Refresh();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("hata", ex.Message);
            }

            dgvCalisanlar.DataSource = null;
            dgvCalisanlar.DataSource = tumCalisan;
            dgvCalisanlar.Columns["Maas"].DefaultCellStyle.Format = "C2";
            dgvCalisanlar.Columns["MesaiUcret"].DefaultCellStyle.Format = "C2";
            dgvCalisanlar.Columns["AnaOdeme"].DefaultCellStyle.Format = "C2";

        }
        /// <summary>
        /// Seçili çalışanın saat bilgisini günceller.
        /// </summary>
        public void Saat()
        {
            if (dgvCalisanlar.SelectedRows.Count > 0)
            {

                var secilen = (Personel)dgvCalisanlar.SelectedRows[0].DataBoundItem;
                if (secilen != null)
                {
                    secilen.Saat = Convert.ToDecimal(npSaat.Value);

                    secilen.MaasAta();
                }
                dgvCalisanlar.Refresh();
            }
            else
            {
                MessageBox.Show("Güncellenecek eleman yok");

            }

        }
        /// <summary>
        /// Saat güncelleme butonuna basıldığında çalışır.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            Saat();
        }
        /// <summary>
        /// Yönetici paneline geçiş yapar.
        /// </summary>
        private void btnYönetici_Click(object sender, EventArgs e)
        {
            Yonetim form1 = new Yonetim(tumCalisan);
            this.Hide();
            form1.Show();
        }
        /// <summary>
        /// Kullanıcı giriş butonuna tıkladığında çalışır.
        /// </summary>
        /// 
        public void GirisButon()
        {
            // İsim içinde rakam olup olmadığını kontrol et
            if (txtIsim.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Rakam girmeyiniz Lütfen !");
                return;
            }
            // Noktalama işareti veya sembol olup olmadığını kontrol et
            if (txtIsim.Text.Any(c => char.IsPunctuation(c) || char.IsSymbol(c)))
            {
                MessageBox.Show("Noktalama işareti veya sembol  girmeyiniz Lütfen !");
                return;
            }
            // İsim boş değilse işlemi devam ettir
            if (!string.IsNullOrWhiteSpace(txtIsim.Text))
            {
               txtIsim.Text= BosluklarıSil(txtIsim.Text);
                isim = txtIsim.Text.ToUpper();
                lblMetin.Visible = true;
                npSaat.Visible = true;
                btnSaat.Visible = true;
                btnYönetici.Visible = true;
                dgvCalisanlar.Visible = true;
                btngeriDon.Visible = true;
                txtIsim.Visible = false;
                btnKaydet.Visible = false;
                lblGiris.Visible = false;
            }
            else
            {

                MessageBox.Show("İsim kutusu boş. Lütfen doldurunuz");
                return;
            }

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            GirisButon();
        }

        //entere basınca  isim kaydeden butonu çalıştırır 
        private void Giris_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnKaydet.PerformClick(); // Enter'a basınca Kaydet butonu çalışsın
            }
        }
        public static string BosluklarıSil(string input)
        {


            // Baştaki ve sondaki boşlukları temizle.
            input = input.Trim();

            // Birden fazla boşluğu tek boşluğa çevir.
            input = Regex.Replace(input, @"\s+", " ");

            return input;
        }

        private void btngeriDon_Click(object sender, EventArgs e)
        {
            lblMetin.Visible = false;
            npSaat.Visible = false;
            btnSaat.Visible = false;
            btnYönetici.Visible = false;
            dgvCalisanlar.Visible = false;
            btngeriDon.Visible = false;

            txtIsim.Visible = true;
            btnKaydet.Visible = true;
            lblGiris.Visible = true;
        }


    }
}

