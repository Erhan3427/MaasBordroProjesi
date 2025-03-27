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
using System.Globalization;

namespace MaasBordroProjesi
{
    public partial class YoneticiPersonel : Form
    {
        private List<Personel> calisanlarHepsi = new List<Personel>();// Tüm çalışanları saklayan liste
        private List<Personel> azCalisanlar = new List<Personel>();// Az çalışanları saklayan liste

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
            lsvtRapor.Columns.Add("İsim", 150);
            lsvtRapor.Columns.Add("Çalışma Saati", 130);
            lsvtRapor.Columns.Add("Maaş", 100);
            lsvtRapor.Columns.Add("Kıdem", 100);
            lsvtRapor.Columns.Add("Uyarı", 160);


            foreach (var kisi in calisanlarHepsi)
            {
                cmbYcalisan.Items.Add(kisi);
            }
            // Butonlara açıklama ekle
            toolTip1.SetToolTip(btnAzCalisan, "Bu buton, az çalışanların JSON dosyasını oluşturur.");
            toolTip1.SetToolTip(btnCalisan, "Bu buton, sadece combobox'tan seçilen çalışanın JSON dosyasını oluşturur.");
            toolTip1.SetToolTip(btnHepsi, "Bu buton, tüm çalışanların JSON dosyasını oluşturur.");
            toolTip1.SetToolTip(btnPDF, "Bu buton, tüm çalışanların PDF dosyasını oluşturur.");
            toolTip1.SetToolTip(btnAzCalisanPdf, "Bu buton, az çalışanların PDF dosyasını oluşturur.");
            toolTip1.SetToolTip(btnAzCalisanlarGoster, "Bu buton, 150 saatten az çalışan personelleri aşağıda listeler.");
            toolTip1.SetToolTip(btnGeriDon, "Bu buton, bir önceki forma geri dönmenizi sağlar.");
            toolTip1.SetToolTip(btnCikis, "Programı Kapatır");
        }

        // Tüm çalışanları JSON formatında kaydeden fonksiyon
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
        // Seçili çalışanı ListView'de gösteren fonksiyon
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
            if (secilen.Saat < 150)
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


        // Seçili çalışanın JSON dosyasını oluşturan fonksiyon
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
                string Tarih = DateTime.Now.ToString("MMMM-yyyy");
                string hedefDizin = Path.Combine(projeDizini, @"..\..\..\", "DataPersonelKisi");

                string memurKlasorYolu = Path.Combine(hedefDizin, secilen.Isim);
                Directory.CreateDirectory(memurKlasorYolu); // Klasör yoksa oluştur
                //projenin içine girmek için 
                string dosyaYolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, memurKlasorYolu, $"{secilen.Isim}_{Tarih}.json");

              

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
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Dosyası|*.pdf";
                saveFileDialog.Title = "PDF Dosyası Kaydet";
                saveFileDialog.FileName = $"PersonelRaporu_{DateTime.Now:yyyy.MM.dd}.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    iTextSharp.text.Document document = new iTextSharp.text.Document();
                    PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    document.Open();

                    string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf");

                    if (!File.Exists(fontPath))
                    {
                        MessageBox.Show("Font dosyası bulunamadı: " + fontPath);
                        return;
                    }

                    BaseFont bfTimes = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(bfTimes, 18, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(bfTimes, 12, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font fontWarning = new iTextSharp.text.Font(bfTimes, 12, iTextSharp.text.Font.BOLD, BaseColor.WHITE);


                    // Başlık ve tarih ekle

                    Paragraph title = new Paragraph("Personel Raporu", fontTitle);
                    title.Alignment = Element.ALIGN_CENTER; // Metni ortala
                    title.Font.Size = 18; // Font boyutunu ayarla
                    document.Add(title);

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
                        PdfPCell cell = new PdfPCell(new Phrase(column.Text, fontNormal));
                        cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                        table.AddCell(cell);
                    }

                    // Verileri ekle
                    bool alternateRow = false;
                    // Listedeki her bir personel bilgisini tabloya ekle
                    foreach (Personel personel in calisanlarHepsi)
                    {
                        PdfPCell cellIsim = new PdfPCell(new Phrase(personel.Isim, fontNormal));
                        PdfPCell cellSaat = new PdfPCell(new Phrase(personel.Saat.ToString(), fontNormal));
                        PdfPCell cellDerece = new PdfPCell(new Phrase(personel.Derece.ToString(), fontNormal));
                        PdfPCell cellMaas = new PdfPCell(new Phrase(personel.Maas.ToString("C2", new CultureInfo("tr-TR")), fontNormal));
                        PdfPCell cellUyari = new PdfPCell(new Phrase(personel.Saat < 150 ? "Çalışma saati yetersiz!" : "", fontWarning)); // Uyarı hücresi




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

        private void cmbYcalisan_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbYcalisan.SelectedItem != null)
            {
                string secilenKıdem = cmbYcalisan.SelectedItem.ToString();
                btnCalisaniGoster_Click(sender, e);
                // Eğer ListView'de yoksa ekle

            }
        }

        private void btnCalisaniGoster_Click(object sender, EventArgs e)
        {
            Goster();

        }

        private void btnAzCalisanlarGoster_Click(object sender, EventArgs e)
        {
            lsvtRapor.Items.Clear();
            foreach (var item in azCalisanlar)
            {
                ListViewItem calisanAz = new ListViewItem(item.Isim);
                calisanAz.SubItems.Add(item.Saat.ToString());
                calisanAz.SubItems.Add(item.Maas.ToString("C2"));
                calisanAz.SubItems.Add(item.Derece.ToString());
                if (item.Saat < 150)
                {
                    calisanAz.BackColor = Color.Red;
                    calisanAz.SubItems.Add("Çalışma saati  az ");
                }


                // ListView'e ekle
                lsvtRapor.Items.Add(calisanAz);
            }

        }
       

        public void AzCalisanlarPDF()
        {
            try
            {
                if (azCalisanlar == null)
                {
                    MessageBox.Show("çalışan yok");
                    return;
                }
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Dosyası|*.pdf";
                saveFileDialog.Title = "PDF Dosyası Kaydet";
                saveFileDialog.FileName = $"AzÇalışanPersonelRaporu_{DateTime.Now:yyyy.MM.dd}.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    iTextSharp.text.Document document = new iTextSharp.text.Document();
                    PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    document.Open();



                    string fontPath = "C:\\Windows\\Fonts\\times.ttf";   // Times New Roman


                    if (!File.Exists(fontPath))
                    {
                        MessageBox.Show("Font dosyası bulunamadı: " + fontPath);
                        return;
                    }

                    BaseFont bfArial = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(bfArial, 18, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(bfArial, 12, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font fontWarning = new iTextSharp.text.Font(bfArial, 12, iTextSharp.text.Font.BOLD, BaseColor.WHITE);

                    // Başlık ve tarih ekle
                    Paragraph title = new Paragraph("Az Çalışan Personel Raporu", fontTitle);
                    title.Alignment = Element.ALIGN_CENTER; // Metni ortala
                    title.Font.Size = 18; // Font boyutunu ayarla
                    document.Add(title);

                    Paragraph date = new Paragraph($"Oluşturulma Tarihi: {DateTime.Now.ToShortDateString()}", fontNormal);
                    date.Alignment = Element.ALIGN_CENTER;
                    document.Add(date);

                    document.Add(new Paragraph("\n"));

                    // Tablo oluştur
                    PdfPTable table = new PdfPTable(lsvtRapor.Columns.Count);
                    table.WidthPercentage = 100;

                    // Başlıkları ekle
                    foreach (ColumnHeader column in lsvtRapor.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.Text, fontNormal));
                        cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                        table.AddCell(cell);
                    }

                    // Verileri ekle
                    bool alternateRow = false;
                    // Listedeki her bir personel bilgisini tabloya ekle
                    foreach (Personel personel in azCalisanlar)
                    {
                        PdfPCell cellIsim = new PdfPCell(new Phrase(personel.Isim, fontNormal));
                        PdfPCell cellSaat = new PdfPCell(new Phrase(personel.Saat.ToString(), fontNormal));
                        PdfPCell cellDerece = new PdfPCell(new Phrase(personel.Derece.ToString(), fontNormal));
                        PdfPCell cellMaas = new PdfPCell(new Phrase(personel.Maas.ToString("C2", new CultureInfo("tr-TR")), fontNormal));
                        PdfPCell cellUyari = new PdfPCell(new Phrase(personel.Saat < 150 ? "Çalışma saati yetersiz!" : "", fontWarning)); // Uyarı hücresi


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

        private void btnAzCalisanPdf_Click(object sender, EventArgs e)
        {
            AzCalisanlarPDF();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTumCalisaniGoster_Click(object sender, EventArgs e)
        {
            lsvtRapor.Items.Clear();
            foreach (var item in calisanlarHepsi)
            {
                ListViewItem calisanlar = new ListViewItem(item.Isim);
                calisanlar.SubItems.Add(item.Saat.ToString());
                calisanlar.SubItems.Add(item.Maas.ToString("C2"));
                calisanlar.SubItems.Add(item.Derece.ToString());
                if (item.Saat < 150)
                {
                    calisanlar.BackColor = Color.Red;
                    calisanlar.SubItems.Add("Çalışma saati  az ");
                }


                // ListView'e ekle
                lsvtRapor.Items.Add(calisanlar);
            }

        }
    }
}

