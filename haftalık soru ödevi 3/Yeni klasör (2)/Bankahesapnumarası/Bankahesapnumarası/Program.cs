using System;
// Giriş: Kullanıcı, para yatırma ve çekme işlemleri için miktar girer. Hesap oluştururken hesap numarası ve bakiye atanır.
// Çıkış: Bakiye sorgulama veya işlem sonucu mesajları konsola yazdırılır.
// Kontrol: Para çekme işleminde bakiye kontrol edilir. Yatırılan miktarın pozitif olması sağlanır.
// Tekrar: Birden fazla kez para yatırma ve çekme işlemi yapılabilir.
// Matematik: Yatırma işleminde bakiye artırılır (Bakiye += miktar). Çekme işleminde bakiye azaltılır (Bakiye -= miktar).

public class BankaHesabi
{
    // Özellikler
    public string HesapNumarasi { get; private set; }
    private decimal Bakiye { get; set; }

    // Yapıcı Metot
    public BankaHesabi(string hesapNumarasi, decimal ilkBakiye)
    {
        HesapNumarasi = hesapNumarasi;
        Bakiye = ilkBakiye;
    }

    // Para Yatırma Metodu
    public void ParaYatir(decimal miktar)
    {
        if (miktar > 0)
        {
            Bakiye += miktar;
            Console.WriteLine($"{miktar:C} yatırıldı. Güncel bakiye: {Bakiye:C}");
        }
        else
        {
            Console.WriteLine("Yatırılacak miktar sıfırdan büyük olmalıdır.");
        }
    }

    // Para Çekme Metodu
    public void ParaCek(decimal miktar)
    {
        if (miktar > 0)
        {
            if (Bakiye >= miktar)
            {
                Bakiye -= miktar;
                Console.WriteLine($"{miktar:C} çekildi. Güncel bakiye: {Bakiye:C}");
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye. İşlem gerçekleştirilemedi.");
            }
        }
        else
        {
            Console.WriteLine("Çekilecek miktar sıfırdan büyük olmalıdır.");
        }
    }

    // Bakiye Bilgisi (Sadece okuma için bir metot)
    public decimal BakiyeGoruntule()
    {
        return Bakiye;
    }
}

// Kullanım örneği
class Program
{
    static void Main()
    {
        // Yeni bir hesap oluşturma
        BankaHesabi hesap = new BankaHesabi("1234567890", 1000m);

        // İşlemler
        Console.WriteLine($"Hesap No: {hesap.HesapNumarasi}");
        Console.WriteLine($"Başlangıç Bakiyesi: {hesap.BakiyeGoruntule():C}");

        hesap.ParaYatir(500m);
        hesap.ParaCek(300m);
        hesap.ParaCek(1500m); // Yetersiz bakiye
    }
}
