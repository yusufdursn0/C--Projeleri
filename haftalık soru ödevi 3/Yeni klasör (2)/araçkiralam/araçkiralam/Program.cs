using System;
// Giriş: Araç oluşturulurken plaka ve günlük ücret girilir. Kiralama ve teslim işlemleri kullanıcı tarafından tetiklenir.
// Çıkış: Araç kiralandığında veya teslim edildiğinde durum mesajları konsola yazdırılır.
// Kontrol: Kiralama işlemi yalnızca araç müsaitse gerçekleştirilir. Teslim işlemi yalnızca araç kiralanmışsa yapılır.
// Tekrar: Araç birden fazla kez kiralanabilir ve teslim alınabilir.
// Matematik: Bu sınıfta matematiksel işlem yoktur, yalnızca mantıksal kontroller yapılır.

public class KiralikArac
{
    // Özellikler
    public string Plaka { get; private set; }
    public decimal GunlukUcret { get; private set; }
    public bool MusaitMi { get; private set; }

    // Yapıcı Metot
    public KiralikArac(string plaka, decimal gunlukUcret)
    {
        Plaka = plaka;
        GunlukUcret = gunlukUcret;
        MusaitMi = true; // Varsayılan olarak araç müsait
    }

    // Metot: Aracı Kirala
    public bool AraciKirala()
    {
        if (MusaitMi)
        {
            MusaitMi = false;
            Console.WriteLine($"Araç {Plaka} kiralandı.");
            return true;
        }
        else
        {
            Console.WriteLine($"Araç {Plaka} şu anda müsait değil.");
            return false;
        }
    }

    // Metot: Aracı Teslim Et
    public void AraciTeslimEt()
    {
        if (!MusaitMi)
        {
            MusaitMi = true;
            Console.WriteLine($"Araç {Plaka} teslim edildi ve tekrar kiralanabilir durumda.");
        }
        else
        {
            Console.WriteLine($"Araç {Plaka} zaten müsait.");
        }
    }

    // Araç Bilgisi Gösterim (isteğe bağlı)
    public void AracBilgisiGoster()
    {
        Console.WriteLine($"Plaka: {Plaka}");
        Console.WriteLine($"Günlük Ücret: {GunlukUcret:C}");
        Console.WriteLine($"Müsait Mi: {(MusaitMi ? "Evet" : "Hayır")}");
    }
}

// Kullanım Örneği
class Program
{
    static void Main()
    {
        // Yeni bir kiralık araç oluşturma
        KiralikArac arac = new KiralikArac("34ABC123", 350m);

        // Araç bilgilerini göster
        arac.AracBilgisiGoster();

        // Araç kiralama işlemi
        arac.AraciKirala();

        // Araç bilgilerini tekrar göster
        arac.AracBilgisiGoster();

        // Araç teslim işlemi
        arac.AraciTeslimEt();

        // Araç bilgilerini tekrar göster
        arac.AracBilgisiGoster();
    }
}
