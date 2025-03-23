using Bordro;
using Bordro.Bordro;
using Org.BouncyCastle.Crypto.Engines;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using System.Windows.Forms;

namespace MaasBordroProjesi
{
    public partial class Form1 : Form
    {
        
        static List<Personel> AzCalisan = new List<Personel>();
        static List<Personel> YeniCalisan = new List<Personel>();
        static List<Personel> Calisan = new List<Personel>();
        static List<Personel> calisanlarinHepsi = new List<Personel>();
        public Form1(List<Personel> GirisPersonel)
        {
            YeniCalisan = GirisPersonel;
            InitializeComponent();
            cbBonus.Visible = false;
         

        }

        public void EskiCalisanCagir()
        {
            calisanlarinHepsi.Clear();
            calisanlarinHepsi.AddRange(AzCalisan);
            calisanlarinHepsi.AddRange(Calisan);
            YeniCalisan.AddRange(calisanlarinHepsi);
            dgvCalisanlar.DataSource = YeniCalisan;
            dgvCalisanlar.Columns["Maas"].DefaultCellStyle.Format = "C2";
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
            dgvCalisanlar.AutoGenerateColumns = true;
            dgvCalisanlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Sütunlarýn otomatik olarak doldurulmasý
            dgvCalisanlar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Satýrlarýn otomatik olarak doldurulmasý

            foreach (var item in MemurDerecesi.TumDereceler())
            {
                cmbKýdem.Items.Add(item);

            }
            EskiCalisanCagir();

        }




        public void kaydet()
        {
            try
            {
                Personel personel;

                if (cmbKýdem.SelectedItem == MemurDerecesi.Yonetici && cbBonus.Checked)
                {
                    personel = new Yonetici();
                    ((Yonetici)personel).bonus = 5000;


                }
                else
                {
                    personel = new Memur();
                }

                if (cmbKýdem.SelectedItem == null)
                {
                    MessageBox.Show("Kýdem seçiniz");
                    return;
                }

                if (txtÝsim.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("Ýsim rakam içeremez");
                    return;
                }

                if (!string.IsNullOrEmpty(txtÝsim.Text) || !string.IsNullOrWhiteSpace(txtÝsim.Text))
                {
                    personel.Isim = txtÝsim.Text;
                }
                else
                {
                    MessageBox.Show("Ýsim boþ olamaz");
                    return;
                }

                if (npSaat.Value != 0)
                {
                    personel.Saat = Convert.ToDecimal(npSaat.Text);
                }
                else
                {
                    MessageBox.Show("Saat boþ olamaz");
                    return;
                }

                if (cmbKýdem.SelectedItem != null)
                {
                    personel.Derece = (MemurDerecesi)cmbKýdem.SelectedItem;
                }
                else
                {
                    MessageBox.Show("Kýdem seçiniz");
                    return;
                }


                personel.MaasAta();

                if (personel.Saat < 150)
                {
                    AzCalisan.Add(personel);
                }
                else
                {
                    Calisan.Add(personel);
                }

                calisanlarinHepsi.Clear();
                calisanlarinHepsi.AddRange(AzCalisan);
                calisanlarinHepsi.AddRange(Calisan);
                YeniCalisan.AddRange(calisanlarinHepsi);
                dgvCalisanlar.DataSource = null;
                dgvCalisanlar.DataSource = YeniCalisan;
                dgvCalisanlar.Columns["Maas"].DefaultCellStyle.Format = "C2";

                foreach (DataGridViewRow row in dgvCalisanlar.Rows)
                {
                    Double saat = Convert.ToDouble(row.Cells["Saat"].Value);
                    if (saat <= 150)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
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



        public void Guncelle()
        {
            try
            {
                if (dgvCalisanlar.SelectedRows.Count > 0)
                {

                    var secilen = (Personel)dgvCalisanlar.SelectedRows[0].DataBoundItem;
                    if (secilen != null)
                    {
                        if (txtÝsim.Text == null) { MessageBox.Show("Ýsim boþ Lütfen isim giriniz "); }
                        else
                        {
                            secilen.Isim = txtÝsim.Text;
                        }
                        secilen.Saat = Convert.ToDecimal(npSaat.Text);
                        if (cmbKýdem.SelectedItem != null)
                        {
                            secilen.Derece = (MemurDerecesi)cmbKýdem.SelectedItem;
                        }
                        secilen.MaasAta();
                        dgvCalisanlar.Refresh();
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

        private void btnYonetim_Click(object sender, EventArgs e)
        {
            if (YeniCalisan.Count == 0)
            {
                MessageBox.Show("Yönetici eklemek için en az bir personel eklemelisiniz");
                return;
            }

            YoneticiPersonel yonetici = new YoneticiPersonel(YeniCalisan);
            yonetici.Show();
            this.Hide();

        }

        private void cmbKýdem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((MemurDerecesi)cmbKýdem.SelectedItem == MemurDerecesi.Yonetici)
            {
                cbBonus.Visible = true;

            }
            else
            {
                cbBonus.Visible = false;
            }
        }

        private void npSaat_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(npSaat.Text))
            {
                npSaat.Value = 0; // Varsayýlan deðer olarak 0 atanýr
            }

        }
    }
}
