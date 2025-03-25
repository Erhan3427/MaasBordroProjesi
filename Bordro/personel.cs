

using Bordro.Bordro;

namespace Bordro
{
    public abstract class Personel
    {
        public int Id { get; set; } 
        public string Isim { get; set; }
        public decimal Saat { get; set; }

        public MemurDerecesi Derece { get; set; }
        public decimal  SaatlikVerilenUcret { get; set; }
        public decimal AnaOdeme { get; set; }
        public decimal MesaiUcret { get; set; }

        public decimal Maas { get; private set; }

        public abstract decimal MaasHesapla();
        /// <summary>
        ///Maashesapla metodundan doğrudan değer alamadığım için ve güncellenmesi için Maas değişkenine atandı.
        /// </summary>
        public void MaasAta()
        {
            Maas = MaasHesapla();
        }



        public override string ToString()
        {
            return Isim + Saat + Derece;
        }


    }
    public class Yonetici : Personel
    {
        public decimal Bonus { get; set; } = 0;
        public override decimal MaasHesapla()
        {
            decimal SonMaas;
            decimal ekMesai = 0;

            if (Saat > 180)
            {
                ekMesai = (Saat - 180) * Derece.SaatlikUcret * 1.5m;
            }
            MesaiUcret= ekMesai;

            SonMaas = (Derece.SaatlikUcret * Saat) + Bonus;

            AnaOdeme = SonMaas;

            return SonMaas + ekMesai;
        }
    }

    public class Memur : Personel
    {
        public override decimal MaasHesapla()
        {
            decimal SonMaas=0;
            decimal ekMesai = 0;

            if (Saat > 180)
            {
                ekMesai = (Saat - 180) * Derece.SaatlikUcret * 1.5m;
            }
            MesaiUcret= ekMesai;
            
                SonMaas = Derece.SaatlikUcret * Saat;

            AnaOdeme= SonMaas;
            
            return SonMaas + ekMesai;

        }
    }
}
