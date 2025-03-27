using System;
using System.Collections.Generic;
// Giriş: Kullanıcı, kitap eklemek için kitap adı, yazar adı ve yayın yılı bilgilerini girer.
// Çıkış: `KitaplariListele` metodu ile kütüphanedeki kitaplar konsola yazdırılır.
// Kontrol: Listeleme sırasında kütüphane boşsa uygun mesaj gösterilir.
// Tekrar: Kullanıcı birden fazla kitap ekleyebilir ve listeleme işlemini birden fazla kez yapabilir.
// Matematik: Bu sınıfta matematiksel işlem yapılmaz, yalnızca liste yönetimi yapılır.

public class Kitap
{
    // Özellikler
    public string Ad { get; private set; }
    public string Yazar { get; private set; }
    public int YayinYili { get; private set; }

    // Yapıcı Metot
    public Kitap(string ad, string yazar, int yayinYili)
    {
        Ad = ad;
        Yazar = yazar;
        YayinYili = yayinYili;
    }

    // Kitap bilgilerini döndürmek için bir metot
    public override string ToString()
    {
        return $"{Ad} - {Yazar} ({YayinYili})";
    }
}

public class Kutuphane
{
    // Özellikler
    private List<Kitap> Kitaplar { get; set; }

    // Yapıcı Metot
    public Kutuphane()
    {
        Kitaplar = new List<Kitap>();
    }

    // Kitap Ekleme Metodu
    public void KitapEkle(Kitap yeniKitap)
    {
        Kitaplar.Add(yeniKitap);
        Console.WriteLine($"'{yeniKitap.Ad}' kütüphaneye eklendi.");
    }

    // Kitapları Listeleme Metodu
    public void KitaplariListele()
    {
        if (Kitaplar.Count == 0)
        {
            Console.WriteLine("Kütüphanede henüz kitap yok.");
            return;
        }

        Console.WriteLine("Kütüphanedeki Kitaplar:");
        foreach (var kitap in Kitaplar)
        {
            Console.WriteLine(kitap); // Kitap sınıfındaki ToString metodu çağrılır
        }
    }
}

// Kullanım Örneği
class Program
{
    static void Main()
    {
        // Yeni bir kütüphane oluşturma
        Kutuphane kutuphane = new Kutuphane();

        // Kitap ekleme
        Kitap kitap1 = new Kitap("1984", "George Orwell", 1949);
        Kitap kitap2 = new Kitap("Savaş ve Barış", "Lev Tolstoy", 1869);

        kutuphane.KitapEkle(kitap1);
        kutuphane.KitapEkle(kitap2);

        // Kütüphanedeki kitapları listeleme
        kutuphane.KitaplariListele();
    }
}
