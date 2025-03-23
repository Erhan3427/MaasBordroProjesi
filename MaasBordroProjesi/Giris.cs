using Bordro;
using Bordro.Bordro;
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
        List<Memur> jsonCalisan = new List<Memur>();
        List<Personel> tumCalisan = new List<Personel>();
        Personel personel;
        public Giris()
        {
            InitializeComponent();
        }

        private void Giriş_Load(object sender, EventArgs e)
        {
            dgvCalisanlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Sütunların otomatik olarak doldurulması
            dgvCalisanlar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Satırların otomatik olarak doldurulması
            try
            {
                jsonCalisan = DosyaOku.MemurOku();

                foreach (Personel item in jsonCalisan)
                {
                    item.Saat = 0;
                    tumCalisan.Add(item);

                    dgvCalisanlar.Refresh();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("hata", ex.Message);
            }
            dgvCalisanlar.AutoGenerateColumns = true;
            dgvCalisanlar.DataSource = null;
            dgvCalisanlar.DataSource = tumCalisan;
            dgvCalisanlar.Columns["Maas"].DefaultCellStyle.Format = "C2";

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
            Form1 form1 = new Form1( tumCalisan);
            form1.ShowDialog();
            this.Hide();
        }
    }
}
