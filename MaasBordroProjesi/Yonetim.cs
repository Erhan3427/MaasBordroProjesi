using Bordro;
using Bordro.Bordro;
using Org.BouncyCastle.Crypto.Engines;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MaasBordroProjesi
{
    public partial class Yonetim : Form
    {
        /// <summary>
        /// 150 saatten az çalışanları, yeni çalışanları ve mevcut çalışanları saklayan listeler.
        /// </summary>
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
            dgvCalisanlar.Columns["AnaOdeme"].DefaultCellStyle.Format = "C2";



            // 150 saatten az çalışanları kırmızı yap
            foreach (DataGridViewRow row in dgvCalisanlar.Rows)
            {
                Double saat = Convert.ToDouble(row.Cells["Saat"].Value);
                if (saat < 150)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }

        }
        public void dgvAyar()
        {
            // DataGridView ayarları
            dgvCalisanlar.AutoGenerateColumns = true;
            dgvCalisanlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Sütunların otomatik olarak doldurulması
            dgvCalisanlar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Satırların otomatik olarak doldurulması

            dgvCalisanlar.DataSource = YeniCalisan;
            dgvCalisanlar.Columns[1].HeaderText = "Ad Soyad";
            dgvCalisanlar.Columns[2].HeaderText = "Saat";
            dgvCalisanlar.Columns[3].HeaderText = "Derece";
            dgvCalisanlar.Columns[4].HeaderText = "Saatlik Ücret";
            dgvCalisanlar.Columns[5].HeaderText = "Ana Ödeme";
            dgvCalisanlar.Columns[6].HeaderText = "Mesai Ücreti";
            dgvCalisanlar.Columns[7].HeaderText = "Maaş";


            if (dgvCalisanlar.Columns["Id"] != null)
            {
                dgvCalisanlar.Columns["Id"].Visible = false;
            }

        }
        /// <summary>
        ///  Arayüz ayarlarını yapar ve çalışanları yükler.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            dgvAyar();
            toolTip1.AutoPopDelay = 5000; // 5 saniye sonra kaybolur
            toolTip1.InitialDelay = 500; // 0.5 saniye sonra gösterir
            toolTip1.ReshowDelay = 200; // Yeniden gösterme süresi
            toolTip1.ShowAlways = true; // Form üzerinde her zaman göster

            dgvCalisanlar.DefaultCellStyle.SelectionBackColor = Color.MidnightBlue;

            dgvCalisanlar.ClearSelection();
            AzCalisan = DosyaOku.AzCalisanOku().Cast<Personel>().ToList();
            // Kıdem (Derece) seçeneklerini ComboBox'a ekleme
            foreach (var item in MemurDerecesi.TumDereceler())
            {
                cmbKıdem.Items.Add(item);

            }
            EskiCalisanCagir();
            toolTip1.SetToolTip(btnDosya, "Personel verilerini güncellemek,dosyaya ve programa kaydetmek için tıklayın");
            toolTip1.SetToolTip(btnGuncelle, "Seçili personelin bilgilerini güncellemek için tıklayın");
            toolTip1.SetToolTip(btnSil, "Seçili personeli listeden silmek için tıklayın");
            toolTip1.SetToolTip(btnKaydet, "Yeni personel eklemek için tıklayın");
            toolTip1.SetToolTip(npSaat, "Çalışma saati (150 saatten az olanlar kırmızı ile işaretlenir)");

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

                if (txtIsim.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("İsim  rakam içeremez. Lütfen tekrar giriniz");
                    return;
                }
                if (txtIsim.Text.Any(p=>char.IsPunctuation(p)||char.IsSymbol(p)))
                {
                    MessageBox.Show("İsim noktalama veya sembol içeremez. Lütfen tekrar giriniz");
                    return;
                }

                if (!string.IsNullOrEmpty(txtIsim.Text) || !string.IsNullOrWhiteSpace(txtIsim.Text))
                {
                    txtIsim.Text=BosluklarıSil(txtIsim.Text);   
                    personel.Isim = txtIsim.Text;
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
                //Her çalışana Id atar
                int yeniId = 1;
                for (int i = 0; i < YeniCalisan.Count; i++)
                {
                    YeniCalisan[i].Id = yeniId;
                    yeniId++;
                }
                personel.Id = yeniId;

                //çalışanın eşleşen derecesine göre saatlik ucret atar
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
                dgvCalisanlar.Columns["AnaOdeme"].DefaultCellStyle.Format = "C2";



                foreach (DataGridViewRow row in dgvCalisanlar.Rows)
                {
                    Double saat = Convert.ToDouble(row.Cells["Saat"].Value);
                    if (saat < 150)
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
                DialogResult result = MessageBox.Show("Bu kişiyi silmek istediğinize emin misiniz?",
                                      "Onay",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return;

                }

                var secilen = (Personel)dgvCalisanlar.SelectedRows[0].DataBoundItem;
                if (secilen != null)
                {
                    for (int i = AzCalisan.Count - 1; i >= 0; i--)
                    {
                        if (AzCalisan[i].Id == secilen.Id)
                        {
                            AzCalisan.RemoveAt(i);
                            break; // Bulunca çık
                        }
                    }

                    // Calisan'dan sil
                    for (int i = Calisan.Count - 1; i >= 0; i--)
                    {
                        if (Calisan[i].Id == secilen.Id)
                        {
                            Calisan.RemoveAt(i);
                            break;
                        }
                    }

                    bool silindiMi = YeniCalisan.Remove(secilen);

                    if (!silindiMi)
                    {
                        MessageBox.Show("Personel listeden kaldırılamadı", "Uyarı",
                                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    dgvCalisanlar.DataSource = null;
                    dgvCalisanlar.DataSource = YeniCalisan;
                    //para formatında yazar
                    dgvCalisanlar.Columns["Maas"].DefaultCellStyle.Format = "C2";
                    dgvCalisanlar.Columns["MesaiUcret"].DefaultCellStyle.Format = "C2";
                    dgvCalisanlar.Columns["AnaOdeme"].DefaultCellStyle.Format = "C2";

                    foreach (DataGridViewRow row in dgvCalisanlar.Rows)
                    {
                        Double saat = Convert.ToDouble(row.Cells["Saat"].Value);
                        if (saat < 150)
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
                        if (txtIsim.Text.Any(char.IsDigit))
                        {
                            MessageBox.Show("Rakam girmeyiniz Lütfen !");
                            return;
                        }

                        //boş ise kullanıcıya soru sorar
                        if (!string.IsNullOrEmpty(txtIsim.Text) || !string.IsNullOrWhiteSpace(txtIsim.Text))
                        {
                            secilen.Isim = txtIsim.Text;
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("İsim kutunuz boş isminiz boş olucak.Bu işlemi yapmak istediğinize emin misiniz?",
                                      "Onay",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);

                            if (result == DialogResult.Yes)
                            {
                                secilen.Isim = txtIsim.Text;
                            }
                            else
                            {
                                return;
                            }
                        }

                        secilen.Saat = Convert.ToDecimal(npSaat.Text);

                        //combodan seçilen dereceyi atar 
                        if (cmbKıdem.SelectedItem != null)
                        {
                            secilen.Derece = (MemurDerecesi)cmbKıdem.SelectedItem;

                        }

                        // Saatlik ücreti yeni dereceye göre atar
                        var dereceListesi = MemurDerecesi.TumDereceler();
                        foreach (var item in dereceListesi)
                        {
                            if (item.DereceAdi == secilen.Derece.DereceAdi)
                            {
                                secilen.SaatlikVerilenUcret = item.SaatlikUcret;

                                break;
                            }
                        }

                        //saatine göre satırı kırmızı yapar
                        foreach (DataGridViewRow row in dgvCalisanlar.Rows)
                        {
                            Double saat = Convert.ToDouble(row.Cells["Saat"].Value);
                            if (saat < 150)
                            {
                                row.DefaultCellStyle.BackColor = Color.Red;
                            }
                            if (saat >= 150)
                            {
                                row.DefaultCellStyle.BackColor = Color.White;
                            }

                            if (saat < 150)
                            {
                                AzCalisan.Add(secilen);
                                break;

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
            txtIsim.Text = ""; // TextBox temizle
            npSaat.Value = 0;  // NumericUpDown sıfırla
            cmbKıdem.SelectedIndex = -1; // ComboBox seçimi kaldır

        }
        public static string BosluklarıSil(string input)
        {
           

            // Baştaki ve sondaki boşlukları temizle.
            input = input.Trim();

            // Birden fazla boşluğu tek boşluğa çevir.
            input = Regex.Replace(input, @"\s+", " ");

            return input;
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

        private void dgvCalisanlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCalisanlar.SelectedRows.Count > 0)
            {
                txtIsim.Text = dgvCalisanlar.SelectedRows[0].Cells[1].Value?.ToString();
                npSaat.Value = Convert.ToDecimal(dgvCalisanlar.SelectedRows[0].Cells[2].Value);
                cmbKıdem.Text = dgvCalisanlar.SelectedRows[0].Cells[3].Value?.ToString();   
            }
        }
    }
}
