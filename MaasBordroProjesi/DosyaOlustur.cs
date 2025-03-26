using Bordro;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Document = System.Reflection.Metadata.Document;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MaasBordroProjesi
{
    public partial class YoneticiPersonel : Form
    {
        private List<Personel> calisanlarHepsi = new List<Personel>();
        private List<Personel> azCalisanlar = new List<Personel>();

        public int bonus;

        public YoneticiPersonel(List<Personel> calisanlar, List<Personel> azCalisan)
        {
            InitializeComponent();
            calisanlarHepsi = calisanlar;
            azCalisanlar = azCalisan;
          

        }

        private void Yonetici_Load(object sender, EventArgs e)
        {
            lsvtRapor.View = View.Details; // Detaylı görünüm modu
            lsvtRapor.GridLines = true; // Çizgileri göster
            toolTip1.AutoPopDelay = 5000; // 5 saniye sonra kaybolur
            toolTip1.InitialDelay = 500; // 0.5 saniye sonra gösterir
            toolTip1.ReshowDelay = 200; // Yeniden gösterme süresi
            toolTip1.ShowAlways = true; // Form üzerinde her zaman göster



            // ListView kolonlarını oluştur
            lsvtRapor.Columns.Add("İsim", 60);
            lsvtRapor.Columns.Add("Çalışma Saati", 130);
            lsvtRapor.Columns.Add("Maaş", 100);
            lsvtRapor.Columns.Add("Kıdem", 100);
            lsvtRapor.Columns.Add("Uyarı", 160);


            foreach (var kisi in calisanlarHepsi)
            {
                cmbYcalisan.Items.Add(kisi);
            }
            
            toolTip1.SetToolTip(btnAzCalisan, "Bu buton az çalışanların json dosyasını oluşturur.");
            toolTip1.SetToolTip(btnCalisan, "Bu buton sadece  comboboxtan seçilen çalışanın json dosyasını oluşturur.");
            toolTip1.SetToolTip(btnHepsi, "Bu buton Tüm çalışanların json dosyasını oluşturur.");
            toolTip1.SetToolTip(btnPDF, "Bu buton tüm çalışanların PDF dosyasını oluşturur.");
        }


        public void jsonKaydet()
        {
            try
            {
                if (calisanlarHepsi == null)
                {
                    MessageBox.Show("çalışan yok");
                    return;
                }
                string projeDizini = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                //projenin içine girmek için 
                string hedefDizin = Path.Combine(projeDizini, @"..\..\..\", "DataPersonel");
                string dosyaYolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, hedefDizin, "Personeller.json");

                if (!Directory.Exists(hedefDizin))
                {
                    Directory.CreateDirectory(hedefDizin);
                }

                if (calisanlarHepsi.Count == 0)
                {
                    MessageBox.Show("Kaydedilecek personel bulunamadı!");
                    return;
                }

                var jsonAyarlar = new JsonSerializerOptions { WriteIndented = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };


                var jsonVeri = JsonSerializer.Serialize(calisanlarHepsi, jsonAyarlar);


                File.WriteAllText(dosyaYolu, jsonVeri);
                MessageBox.Show("Personel verileri başarıyla kaydedildi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata", ex.Message);
            }
        }

        private void btnHepsi_Click(object sender, EventArgs e)
        {
            jsonKaydet();
        }


        Personel secilen;
        public void Goster()
        {

            if (cmbYcalisan.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir çalışan seçiniz!");
                return;
            }

            var secili = (Personel)cmbYcalisan.SelectedItem;
            foreach (var calisan in calisanlarHepsi)
            {
                if (calisan.Id == secili.Id)
                {
                    secilen = calisan;
                    break;
                }

            }
            if (secilen == null)
            {
                MessageBox.Show("Seçili çalışan bulunamadı.");
                return;
            }
            lsvtRapor.Items.Clear();

            // Yeni ListView item oluştur
            ListViewItem item = new ListViewItem(secilen.Isim);
            item.SubItems.Add(secilen.Saat.ToString());
            item.SubItems.Add(secilen.Maas.ToString("C2"));
            item.SubItems.Add(secilen.Derece.ToString());
            if (secilen.Saat < 180)
            {
                item.BackColor = Color.Red;
                item.SubItems.Add("Çalışma saati  az ");
            }


            // ListView'e ekle
            lsvtRapor.Items.Add(item);

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Goster();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Goster();
        }

        public void CalisanJson()
        {
            try
            {
                if (cmbYcalisan.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen bir çalışan seçiniz!");
                    return;
                }
                if (secilen == null)
                {
                    MessageBox.Show("Calışan Seçilmedi !");
                    return;
                }

                string projeDizini = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string Tarih = DateTime.Now.ToString("MM-yyyy");
                //projenin içine girmek için 
                string hedefDizin = Path.Combine(projeDizini, @"..\..\..\", "DataPersonelKisi");
                string dosyaYolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, hedefDizin, $"{secilen.Isim}_{Tarih}.json");

                if (!Directory.Exists(hedefDizin))
                {
                    Directory.CreateDirectory(hedefDizin);
                }

                var jsonAyarlar = new JsonSerializerOptions { WriteIndented = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
                string jsonVeri = JsonSerializer.Serialize(secilen, jsonAyarlar);
                File.WriteAllText(dosyaYolu, jsonVeri);
                MessageBox.Show("Personel verileri başarıyla kaydedildi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata", ex.Message);

            }


        }




        private void btnCalisan_Click(object sender, EventArgs e)
        {
            CalisanJson();
        }


        // ...

        public void PDF()
        {


            try
            {
                if (calisanlarHepsi == null)
                {
                    MessageBox.Show("çalışan yok");
                    return;
                }
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Dosyası|*.pdf";
                saveFileDialog.Title = "PDF Dosyası Kaydet";
                saveFileDialog.FileName = $"PersonelRaporu_{DateTime.Now:yyyyMMdd}.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    iTextSharp.text.Document document = new iTextSharp.text.Document(); // Change to iTextSharp.text.Document
                    PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    document.Open();

                    // Başlık ve tarih ekle
                    Paragraph title = new Paragraph("Personel Raporu");
                    title.Alignment = Element.ALIGN_CENTER; // Metni ortala
                    title.Font.Size = 18; // Font boyutunu ayarla

                    Paragraph date = new Paragraph($"Oluşturulma Tarihi: {DateTime.Now.ToShortDateString()}");
                    date.Alignment = Element.ALIGN_CENTER;
                    date.Font.Size = 12; // Font boyutunu ayarla
                    document.Add(date);


                    document.Add(new Paragraph("\n"));

                    // Tablo oluştur
                    PdfPTable table = new PdfPTable(lsvtRapor.Columns.Count);
                    table.WidthPercentage = 100;

                    // Başlıkları ekle
                    foreach (ColumnHeader column in lsvtRapor.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.Text));
                        cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                        table.AddCell(cell);
                    }

                    // Verileri ekle
                    bool alternateRow = false;
                    // Listedeki her bir personel bilgisini tabloya ekle
                    foreach (Personel personel in calisanlarHepsi)
                    {
                        PdfPCell cellIsim = new PdfPCell(new Phrase(personel.Isim));
                        PdfPCell cellSaat = new PdfPCell(new Phrase(personel.Saat.ToString()));
                        PdfPCell cellDerece = new PdfPCell(new Phrase(personel.Derece.ToString()));
                        PdfPCell cellMaas = new PdfPCell(new Phrase(personel.Maas.ToString("C2"))); // Para birimi formatı
                        PdfPCell cellUyari = new PdfPCell(new Phrase(personel.Saat <= 150 ? "Çalışma saati yetersiz!" : "")); // Uyarı hücresi




                        if (alternateRow)
                        {
                            cellIsim.BackgroundColor = BaseColor.LIGHT_GRAY;
                            cellSaat.BackgroundColor = BaseColor.LIGHT_GRAY;
                            cellDerece.BackgroundColor = BaseColor.LIGHT_GRAY;
                            cellMaas.BackgroundColor = BaseColor.LIGHT_GRAY;

                        }
                        if (personel.Saat < 150)
                        {
                            cellUyari.BackgroundColor = BaseColor.RED;
                        }
                        else if (alternateRow)
                        {
                            cellUyari.BackgroundColor = BaseColor.LIGHT_GRAY;
                        }

                        table.AddCell(cellIsim);
                        table.AddCell(cellSaat);
                        table.AddCell(cellMaas);
                        table.AddCell(cellDerece);
                        table.AddCell(cellUyari);

                        alternateRow = !alternateRow;
                    }

                    document.Add(table);
                    document.Close();

                    MessageBox.Show("PDF başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        private void btnPdf_Click(object sender, EventArgs e)
        {
            PDF();
        }

        private void cmbYcalisan_Leave(object sender, EventArgs e)
        {

        }

        private void btnAzCalisan_Click(object sender, EventArgs e)
        {

            try
            {
                if (azCalisanlar == null)
                {
                    MessageBox.Show("çalışan yok");
                    return;
                }
                string projeDizini = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                //projenin içine girmek için 
                string hedefDizin = Path.Combine(projeDizini, @"..\..\..\", "DataAzCalisan");
                string dosyaYolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, hedefDizin, "AzCalisanPersoneller.json");

                if (!Directory.Exists(hedefDizin))
                {
                    Directory.CreateDirectory(hedefDizin);
                }

                if (azCalisanlar.Count == 0)
                {
                    MessageBox.Show("Kaydedilecek personel bulunamadı!");
                    return;
                }

                var jsonAyarlar = new JsonSerializerOptions { WriteIndented = true, Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping };


                var jsonVeri = JsonSerializer.Serialize(azCalisanlar, jsonAyarlar);


                File.WriteAllText(dosyaYolu, jsonVeri);
                MessageBox.Show("Personel verileri başarıyla kaydedildi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata", ex.Message);
            }
        }

      

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
