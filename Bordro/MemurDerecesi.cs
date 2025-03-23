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
            public static  MemurDerecesi Yonetici = new MemurDerecesi { DereceAdi = "Yönetici", SaatlikUcret = 600 };
            public static readonly MemurDerecesi UstKidemli = new MemurDerecesi { DereceAdi = "Üst Kıdemli", SaatlikUcret = 550 };
            public static readonly MemurDerecesi Kidemli = new MemurDerecesi { DereceAdi = "Kidemli", SaatlikUcret = 535 };
            public static readonly MemurDerecesi OrtaKidemli = new MemurDerecesi { DereceAdi = "Orta Kıdemli", SaatlikUcret = 520 };
            public static readonly MemurDerecesi Deneyimli = new MemurDerecesi { DereceAdi = "Deneyimli", SaatlikUcret = 510 };
            public static readonly MemurDerecesi YeniBaslayan = new MemurDerecesi { DereceAdi = "Yeni Başlayan", SaatlikUcret = 500 };

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

            public override string ToString()
            {
                return DereceAdi;
            }

            
        }
    }
}
