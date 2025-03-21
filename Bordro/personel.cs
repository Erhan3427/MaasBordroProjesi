namespace Bordro
{
    public abstract class Personel
    {
        public string İsim { get; set; }
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
            return İsim + Saat + Derece;
        }


    }
   public  class Yonetici : Personel
    {
        public override decimal MaasHesapla( )
        {
            decimal SonMaas = (int)Derece * Saat;
            return SonMaas;


        }
    }

   public class Memur : Personel
    {

        public override decimal MaasHesapla()
        {
            decimal SonMaas;
            if (Saat > 180)
            {
                SonMaas = ((int)Derece * 1.5m)*Saat;
                return SonMaas;
            }
            else
            {
                SonMaas = (int)Derece * Saat;
                return SonMaas;
            }
        }

    }
}
