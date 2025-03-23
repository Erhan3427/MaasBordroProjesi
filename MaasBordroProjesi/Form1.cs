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
            dgvCalisanlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // S�tunlar�n otomatik olarak doldurulmas�
            dgvCalisanlar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Sat�rlar�n otomatik olarak doldurulmas�

            foreach (var item in MemurDerecesi.TumDereceler())
            {
                cmbK�dem.Items.Add(item);

            }
            EskiCalisanCagir();

        }




        public void kaydet()
        {
            try
            {
                Personel personel;

                if (cmbK�dem.SelectedItem == MemurDerecesi.Yonetici && cbBonus.Checked)
                {
                    personel = new Yonetici();
                    ((Yonetici)personel).bonus = 5000;


                }
                else
                {
                    personel = new Memur();
                }

                if (cmbK�dem.SelectedItem == null)
                {
                    MessageBox.Show("K�dem se�iniz");
                    return;
                }

                if (txt�sim.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("�sim rakam i�eremez");
                    return;
                }

                if (!string.IsNullOrEmpty(txt�sim.Text) || !string.IsNullOrWhiteSpace(txt�sim.Text))
                {
                    personel.Isim = txt�sim.Text;
                }
                else
                {
                    MessageBox.Show("�sim bo� olamaz");
                    return;
                }

                if (npSaat.Value != 0)
                {
                    personel.Saat = Convert.ToDecimal(npSaat.Text);
                }
                else
                {
                    MessageBox.Show("Saat bo� olamaz");
                    return;
                }

                if (cmbK�dem.SelectedItem != null)
                {
                    personel.Derece = (MemurDerecesi)cmbK�dem.SelectedItem;
                }
                else
                {
                    MessageBox.Show("K�dem se�iniz");
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
                        if (txt�sim.Text == null) { MessageBox.Show("�sim bo� L�tfen isim giriniz "); }
                        else
                        {
                            secilen.Isim = txt�sim.Text;
                        }
                        secilen.Saat = Convert.ToDecimal(npSaat.Text);
                        if (cmbK�dem.SelectedItem != null)
                        {
                            secilen.Derece = (MemurDerecesi)cmbK�dem.SelectedItem;
                        }
                        secilen.MaasAta();
                        dgvCalisanlar.Refresh();
                    }
                }
                else
                {
                    MessageBox.Show("G�ncellenecek eleman yok");

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
                MessageBox.Show("Y�netici eklemek i�in en az bir personel eklemelisiniz");
                return;
            }

            YoneticiPersonel yonetici = new YoneticiPersonel(YeniCalisan);
            yonetici.Show();
            this.Hide();

        }

        private void cmbK�dem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((MemurDerecesi)cmbK�dem.SelectedItem == MemurDerecesi.Yonetici)
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
                npSaat.Value = 0; // Varsay�lan de�er olarak 0 atan�r
            }

        }
    }
}
