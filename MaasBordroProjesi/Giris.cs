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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaasBordroProjesi
{

    public partial class Giris : Form
    {
        public static string isim;
        List<Memur> jsonCalisan = new List<Memur>();
        List<Personel> tumCalisan = new List<Personel>();
        Personel personel;
        public Giris()
        {
            InitializeComponent();
            lblMetin.Visible = false;
            npSaat.Visible = false;
            btnSaat.Visible = false;
            btnYönetici.Visible = false;
            dgvCalisanlar.Visible = false;
        }

        MemurDerecesi memurSaat = new MemurDerecesi();
        private void Giriş_Load(object sender, EventArgs e)
        {
            dgvCalisanlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Sütunların otomatik olarak doldurulması
            dgvCalisanlar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Satırların otomatik olarak doldurulması
            dgvCalisanlar.AutoGenerateColumns = true;
            try
            {
                jsonCalisan = DosyaOku.MemurOku();

                foreach (Personel item in jsonCalisan)
                {
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
        }
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

        private void button1_Click(object sender, EventArgs e)
        {
            Saat();
        }

        private void btnYönetici_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(tumCalisan);
            form1.ShowDialog();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtİsim.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Rakam girmeyiniz Lütfen !");
                return;
            }
            if (!string.IsNullOrEmpty(txtİsim.Text) || !string.IsNullOrWhiteSpace(txtİsim.Text))
            {
                isim = txtİsim.Text;
                lblMetin.Visible = true;
                npSaat.Visible = true;
                btnSaat.Visible = true;
                btnYönetici.Visible = true;
                dgvCalisanlar.Visible = true;
                txtİsim.Visible = false;
                btnKaydet.Visible = false;
                lblGiris.Visible = false;
            }
            else
            {

                MessageBox.Show("İsim kutusu boş Lütfen doldurunuz");
                return;
            }
         
        }
    }
}
