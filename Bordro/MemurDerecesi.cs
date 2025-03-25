using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bordro
{
    namespace Bordro
    {
        public class MemurDerecesi
        {
            public string DereceAdi { get; set; }
            public decimal SaatlikUcret { get; set; }

            // Önceden tanımlanmış dereceler
            public static MemurDerecesi Yonetici = new MemurDerecesi { DereceAdi = "Yönetici", SaatlikUcret = 600 };
            public static MemurDerecesi UstKidemli = new MemurDerecesi { DereceAdi = "Üst Kıdemli", SaatlikUcret = 550 };
            public static MemurDerecesi Kidemli = new MemurDerecesi { DereceAdi = "Kidemli", SaatlikUcret = 535 };
            public static MemurDerecesi OrtaKidemli = new MemurDerecesi { DereceAdi = "Orta Kıdemli", SaatlikUcret = 520 };
            public static MemurDerecesi Deneyimli = new MemurDerecesi { DereceAdi = "Deneyimli", SaatlikUcret = 510 };
            public static MemurDerecesi YeniBaslayan = new MemurDerecesi { DereceAdi = "Yeni Başlayan", SaatlikUcret = 500 };

            // Tüm dereceleri bir liste olarak döndüren metot
            public static List<MemurDerecesi> TumDereceler()
            {
                return new List<MemurDerecesi>
            {
                Yonetici,
                UstKidemli,
                Kidemli,
                OrtaKidemli,
                Deneyimli,
                YeniBaslayan
            };
            }

            //sadece DereceAdı yazdırılıyor.
            public override string ToString()
            {
                return DereceAdi;
            }


        }
    }
}
