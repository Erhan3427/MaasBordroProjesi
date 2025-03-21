using Bordro;
using System.Windows.Forms;

namespace MaasBordroProjesi
{
    public partial class Form1 : Form
    {
        List<Personel> AzCalisan = new List<Personel>();
        List<Personel> Calisan = new List<Personel>();
        List<string> strings = new List<string>();
        public Form1()
        {
            InitializeComponent();

        }


        public static string isim(MemurDerecesi memur)
        {
            // Switch-case yapýsý
            switch (memur)
            {
                case MemurDerecesi.UstKidemli:
                    return "Üst Kýdemli";

                case MemurDerecesi.Kidemli:
                    return "Kýdemli";
                case MemurDerecesi.OrtaKidemli:
                    return "Orta Kýdemli";
                case MemurDerecesi.Deneyimli:
                    return "Deneyimli";

                case MemurDerecesi.YeniBaslayan:
                    return "Yeni Baþlayan";

                default:
                    return "";
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dgvCalisanlar.AutoGenerateColumns = true;

            foreach (MemurDerecesi memur in Enum.GetValues(typeof(MemurDerecesi)))
            {
                cmbKýdem.Items.Add(memur);
            }
        }

        public void kaydet()
        {
            try
            {
                Personel personel = new Memur();
                personel.Ýsim = txtÝsim.Text;
                personel.Saat = Convert.ToDecimal(npSaat.Text);
                if (cmbKýdem.SelectedItem != null)
                {
                    personel.Derece = (MemurDerecesi)cmbKýdem.SelectedItem;
                }
                personel.MaasAta();

                if (personel.Saat < 150)
                {

                    dgvCalisanlar.Columns[0].Name = "Az çalýþanlar";
                    AzCalisan.Add(personel);
                    dgvCalisanlar.DataSource = null;
                    dgvCalisanlar.Cell
                }
                else
                {
                    Calisan.Add(personel);
                    dgvCalisanlar.DataSource = null;
                    dgvCalisanlar.DataSource = Calisan;
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

        private void dgvCalisanlar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
