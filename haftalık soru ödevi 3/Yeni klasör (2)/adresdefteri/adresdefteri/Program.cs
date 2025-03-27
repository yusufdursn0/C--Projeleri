using System;
// Giriş: Kişi oluşturulurken ad, soyad ve telefon numarası bilgileri girilir.
// Çıkış: Kişinin tam adı ve telefon numarası `KisiBilgisi` metodu ile döndürülür.
// Kontrol: Veri doğrulama yapılmaz, ancak ileride telefon numarası format kontrolü eklenebilir.
// Tekrar: Bilgiler istenildiği kadar görüntülenebilir.
// Matematik: Bu sınıfta matematiksel işlem yapılmaz.

public class Kisi
{
    // Özellikler
    public string Ad { get; private set; }
    public string Soyad { get; private set; }
    public string TelefonNumarasi { get; private set; }

    // Yapıcı Metot
    public Kisi(string ad, string soyad, string telefonNumarasi)
    {
        Ad = ad;
        Soyad = soyad;
        TelefonNumarasi = telefonNumarasi;
    }

    // KisiBilgisi Metodu
    public string KisiBilgisi()
    {
        return $"Tam Ad: {Ad} {Soyad}, Telefon Numarası: {TelefonNumarasi}";
    }
}

// Kullanım Örneği
class Program
{
    static void Main()
    {
        // Yeni bir kişi oluşturma
        Kisi kisi = new Kisi("Ahmet", "Yılmaz", "0532-123-4567");

        // Kişi bilgilerini görüntüleme
        Console.WriteLine(kisi.KisiBilgisi());
    }
}

