using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace Bordro
{
    public static class DosyaOku
    {
        public static List<Memur> MemurOku()
        {
            string projeDizini = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string hedefDizin = Path.Combine(projeDizini, @"..\..\..\", "DataPersonel");
            string dosyaYolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\", "DataPersonel", "Personeller.json");



            try
            {
                if (!File.Exists(dosyaYolu))
                {
                    throw new Exception("Dosya bulunamadı");
                }

                string jsonVeri = File.ReadAllText(dosyaYolu);
                var calisanlar = JsonSerializer.Deserialize<List<Memur>>(jsonVeri, new JsonSerializerOptions { WriteIndented = true, PropertyNameCaseInsensitive = true });
                return calisanlar ?? new List<Memur>(); // Null kontrolü
            }
            catch (Exception ex)
            {
                throw new Exception("Dosya okuma hatası", ex);
            }
        }
    }
}
