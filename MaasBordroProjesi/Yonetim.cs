using Bordro;
using Bordro.Bordro;
using Org.BouncyCastle.Crypto.Engines;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using System.Windows.Forms;

namespace MaasBordroProjesi
{
    public partial class Yonetim : Form
    {
        //Personel Listeleri
        static List<Personel> AzCalisan = new List<Personel>();
        static List<Personel> YeniCalisan = new List<Personel>();
        static List<Personel> Calisan = new List<Personel>();
        public Yonetim(List<Personel> GirisPersonel)
        {
            YeniCalisan = GirisPersonel;
            InitializeComponent();
            cbBonus.Visible = false; //başlangıçta bonus kutusu gizlenir
            lblMesaj.Text = " Hoşgeldin " + Giris.isim; // Set the text property of the label
        }

        /// <summary>
        /// Önceki çalışanları getirerek listeye ekler ve DataGridView'e yansıtır.
        /// 150 saatten az çalışanlar kırmızı olarak işaretlenir.
        /// </summary>
        public void EskiCalisanCagir()
        {

            dgvCalisanlar.DataSource = YeniCalisan;
            dgvCalisanlar.Columns["Maas"].DefaultCellStyle.Format = "C2";
            dgvCalisanlar.Columns["MesaiUcret"].DefaultCellStyle.Format = "C2";


            // 150 saatten az çalışanları kırmızı yap
            foreach (DataGridViewRow row in dgvCalisanlar.Rows)
            {
                Double saat = Convert.ToDouble(row.Cells["Saat"].Value);
                if (saat <= 150)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // DataGridView ayarları
            dgvCalisanlar.AutoGenerateColumns = true;
            dgvCalisanlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Sütunların otomatik olarak doldurulması
            dgvCalisanlar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Satırların otomatik olarak doldurulması
            dgvCalisanlar.ClearSelection();

            // Kıdem (Derece) seçeneklerini ComboBox'a ekleme
            foreach (var item in MemurDerecesi.TumDereceler())
            {
                cmbKıdem.Items.Add(item);

            }
            EskiCalisanCagir();

        }



        // Yeni personeli listeye ekler ve ekrana yansıtır.
        public void kaydet()
        {
            Personel personel;
            try
            {

                // Eğer Yönetici seçilmiş ve bonus işaretlenmişse yönetici olarak bonus ekle
                if (cmbKıdem.SelectedItem == MemurDerecesi.Yonetici && cbBonus.Checked)
                {
                    personel = new Yonetici();
                    ((Yonetici)personel).Bonus = 5000;


                }
                else
                {
                    personel = new Memur();
                }

                if (cmbKıdem.SelectedItem == null)
                {
                    MessageBox.Show("Kıdem seçiniz");
                    return;
                }

                if (txtİsim.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("İsim  rakam içeremez. Lütfen tekrar giriniz");
                    return;
                }
                if (txtİsim.Text.Any(char.IsPunctuation))
                {
                    MessageBox.Show("İsim  Noktalama içeremez. Lütfen tekrar giriniz");
                    return;
                }

                if (!string.IsNullOrEmpty(txtİsim.Text) || !string.IsNullOrWhiteSpace(txtİsim.Text))
                {
                    personel.Isim = txtİsim.Text;
                }
                else
                {
                    MessageBox.Show("İsim boş olamaz");
                    return;
                }

                if (npSaat.Value != 0)
                {
                    personel.Saat = Convert.ToDecimal(npSaat.Text);
                }
                else
                {
                    MessageBox.Show("Saat boş olamaz");
                    return;
                }


                if (cmbKıdem.SelectedItem != null)
                {
                    personel.Derece = (MemurDerecesi)cmbKıdem.SelectedItem;
                }
                else
                {
                    MessageBox.Show("Kıdem seçiniz");
                    return;
                }

                personel.MaasAta();
                int yeniId = 1;
                for (int i = 0; i < YeniCalisan.Count; i++)
                {
                    YeniCalisan[i].Id = yeniId;
                    yeniId++;
                }
                personel.Id = yeniId;

                var derece = MemurDerecesi.TumDereceler();
                foreach (var item in derece)
                {
                    if (item.DereceAdi == personel.Derece.DereceAdi)
                        personel.SaatlikVerilenUcret = item.SaatlikUcret;
                }

                // 150 saatten az çalışanları ayır
                if (personel.Saat < 150)
                {
                    AzCalisan.Add(personel);

                }
                else
                {

                    Calisan.Add(personel);
                }


                YeniCalisan.AddRange(personel);
                dgvCalisanlar.DataSource = null;
                dgvCalisanlar.DataSource = YeniCalisan;
                dgvCalisanlar.Columns["Maas"].DefaultCellStyle.Format = "C2";
                dgvCalisanlar.Columns["MesaiUcret"].DefaultCellStyle.Format = "C2";


                foreach (DataGridViewRow row in dgvCalisanlar.Rows)
                {
                    Double saat = Convert.ToDouble(row.Cells["Saat"].Value);
                    if (saat <= 150)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
                Temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            kaydet();
        }


        //Calisanı Siler
        public void Sil()
        {
            if (dgvCalisanlar.SelectedRows.Count > 0)
            {


                var secilen = (Personel)dgvCalisanlar.SelectedRows[0].DataBoundItem;
                if (secilen != null)
                {
                    if (secilen.Saat < 150)
                    {
                        AzCalisan.Remove(secilen);

                    }
                    else
                    {
                        Calisan.Remove(secilen);

                    }


                    YeniCalisan.Remove(secilen);


                    dgvCalisanlar.DataSource = null;
                    dgvCalisanlar.DataSource = YeniCalisan;

                    dgvCalisanlar.Columns["Maas"].DefaultCellStyle.Format = "C2";
                    dgvCalisanlar.Columns["MesaiUcret"].DefaultCellStyle.Format = "C2";

                    foreach (DataGridViewRow row in dgvCalisanlar.Rows)
                    {
                        Double saat = Convert.ToDouble(row.Cells["Saat"].Value);
                        if (saat <= 150)
                        {

                            row.DefaultCellStyle.BackColor = Color.Red;
                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("Silinecek eleman yok");
            }
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            Sil();
        }


        // Seçili çalışanın bilgilerini günceller.
        public void Guncelle()
        {
            try
            {
                if (dgvCalisanlar.SelectedRows.Count > 0)
                {

                    var secilen = (Personel)dgvCalisanlar.SelectedRows[0].DataBoundItem;
                    if (secilen != null)
                    {
                        if (txtİsim.Text.Any(char.IsDigit))
                        {
                            MessageBox.Show("Rakam girmeyiniz Lütfen !");
                            return;
                        }
                        if (!string.IsNullOrEmpty(txtİsim.Text) || !string.IsNullOrWhiteSpace(txtİsim.Text))
                        {
                            secilen.Isim = txtİsim.Text;
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("İsim kutunuz boş isminiz boş olucak.Bu işlemi yapmak istediğinize emin misiniz?",
                                      "Onay",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);

                            if (result == DialogResult.Yes)
                            {
                                secilen.Isim = txtİsim.Text;
                            }
                            else
                            {
                                return;
                            }
                        }
                        var dereceListesi = MemurDerecesi.TumDereceler();
                        foreach (var item in dereceListesi)
                        {
                            if (item.DereceAdi == secilen.Derece.DereceAdi)
                            {
                                secilen.SaatlikVerilenUcret = item.SaatlikUcret;
                                dgvCalisanlar.Refresh();
                                break;  // Eşleşmeyi bulunca döngüden çık
                            }
                        }

                        secilen.Saat = Convert.ToDecimal(npSaat.Text);
                        if (cmbKıdem.SelectedItem != null)
                        {
                            secilen.Derece = (MemurDerecesi)cmbKıdem.SelectedItem;

                        }
                        foreach (DataGridViewRow row in dgvCalisanlar.Rows)
                        {
                            Double saat = Convert.ToDouble(row.Cells["Saat"].Value);
                            if (saat <= 150)
                            {
                                row.DefaultCellStyle.BackColor = Color.Red;
                            }
                            if (saat > 150)
                            {
                                row.DefaultCellStyle.BackColor = Color.White;
                            }

                        }

                        secilen.MaasAta();
                        dgvCalisanlar.Refresh();
                        Temizle();
                    }





                }
                else
                {
                    MessageBox.Show("Güncellenecek eleman yok");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);

            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Guncelle();
        }


        //Yönetici Seçilince Bonus kutusu aktif olucak.
        private void cmbKıdem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((MemurDerecesi)cmbKıdem.SelectedItem == MemurDerecesi.Yonetici)
            {
                cbBonus.Visible = true;

            }
            else
            {
                cbBonus.Visible = false;
            }
        }
        private void Temizle()
        {
            txtİsim.Text = ""; // TextBox temizle
            npSaat.Value = 0;  // NumericUpDown sıfırla
            cmbKıdem.SelectedIndex = -1; // ComboBox seçimi kaldır

        }
        //Dosya oluşturulan Forma Geçer
        private void btnYonetim_Click(object sender, EventArgs e)
        {
            if (YeniCalisan.Count == 0)
            {
                MessageBox.Show("Çalişanların dosyasını oluşturmak için en az bir personel eklemelisiniz");
                return;
            }
         

            YoneticiPersonel yonetici = new YoneticiPersonel(YeniCalisan, AzCalisan);
            this.Hide();
            yonetici.ShowDialog();
            this.Show();

        }

    }
}
