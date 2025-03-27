using System;
// Giriş: Ürün adı, fiyatı ve opsiyonel olarak indirim oranı girilir.
// Çıkış: İndirimli fiyat ve ürün bilgileri kullanıcıya döndürülür veya konsola yazdırılır.
// Kontrol: İndirim oranı 0 ile 50 arasında sınırlandırılır.
// Tekrar: İndirim oranı birden fazla kez değiştirilebilir ve ürün bilgileri tekrar tekrar görüntülenebilir.
// Matematik: İndirimli fiyat hesaplanır (Fiyat * (1 - Indirim / 100)).

public class Urun
{
    // Özellikler
    public string Ad { get; private set; }
    public decimal Fiyat { get; private set; }

    private decimal indirim;
    public decimal Indirim
    {
        get { return indirim; }
        set
        {
            if (value >= 0 && value <= 50)
            {
                indirim = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(value), "İndirim 0 ile 50 arasında olmalıdır.");
            }
        }
    }

    // Yapıcı Metot
    public Urun(string ad, decimal fiyat)
    {
        Ad = ad;
        Fiyat = fiyat;
        Indirim = 0; // Varsayılan olarak indirim yok
    }

    // İndirimli Fiyat Metodu
    public decimal IndirimliFiyat()
    {
        return Fiyat * (1 - (Indirim / 100));
    }

    // Ürün Bilgisi Gösterim Metodu (isteğe bağlı)
    public void UrunBilgisiGoster()
    {
        Console.WriteLine($"Ürün: {Ad}");
        Console.WriteLine($"Fiyat: {Fiyat:C}");
        Console.WriteLine($"İndirim: %{Indirim}");
        Console.WriteLine($"İndirimli Fiyat: {IndirimliFiyat():C}");
    }
}

// Kullanım Örneği
class Program
{
    static void Main()
    {
        try
        {
            // Yeni bir ürün oluşturma
            Urun urun = new Urun("Telefon", 5000m);

            // Ürün bilgilerini göster
            urun.UrunBilgisiGoster();

            // İndirim ekle ve tekrar göster
            urun.Indirim = 20; // %20 indirim
            urun.UrunBilgisiGoster();

            // Geçersiz bir indirim denemesi
            urun.Indirim = 60; // Hata fırlatır
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Hata: {ex.Message}");
        }
    }
}
