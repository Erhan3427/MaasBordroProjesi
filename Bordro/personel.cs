

using Bordro.Bordro;

namespace Bordro
{
    public abstract class Personel
    {
        public string Isim { get; set; }
        public decimal Saat { get; set; }

        public MemurDerecesi Derece { get; set; }
        public decimal Maas { get; private set; }

        public abstract decimal MaasHesapla();
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
        public decimal bonus { get; set; } = 0;
        public override decimal MaasHesapla()
        {
            decimal SonMaas;
            decimal ekMesai = 0;

            if (Saat > 180)
            {
                ekMesai = (Saat - 180) * Derece.SaatlikUcret * 1.5m;
            }

            SonMaas = (Derece.SaatlikUcret * Saat) + bonus;
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
            
                SonMaas = Derece.SaatlikUcret * Saat;
            
            return SonMaas + ekMesai;

        }
    }
}
