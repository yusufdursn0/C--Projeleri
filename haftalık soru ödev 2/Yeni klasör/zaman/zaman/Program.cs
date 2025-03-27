using System;
using System.Collections.Generic;

public class ZamanYolculugu
{
    public static List<string> GecerliTarihler()
    {
        List<string> tarihler = new List<string>();
        for (int yil = 2024; yil <= 3000; yil++)
        {
            if (YilKontrol(yil))
            {
                for (int ay = 1; ay <= 12; ay++)
                {
                    if (AyKontrol(ay))
                    {
                        for (int gun = 2; gun <= 31; gun++)
                        {
                            if (GunKontrol(gun, ay, yil))
                            {
                                tarihler.Add($"{gun:D2}-{ay:D2}-{yil}");
                            }
                        }
                    }
                }
            }
        }
        return tarihler;
    }

    private static bool GunKontrol(int gun, int ay, int yil)
    {
        if (!AsalMi(gun)) return false;
        if ((ay == 4 || ay == 6 || ay == 9 || ay == 11) && gun > 30) return false;
        if (ay == 2 && (gun > 29 || (gun == 29 && !ArtikYilMi(yil)))) return false;
        return true;
    }

    private static bool AyKontrol(int ay)
    {
        int basamakToplami = 0;
        int geciciAy = ay;
        while (geciciAy > 0)
        {
            basamakToplami += geciciAy % 10;
            geciciAy /= 10;
        }
        return basamakToplami % 2 == 0;
    }

    private static bool YilKontrol(int yil)
    {
        int basamakToplami = 0;
        int orijinalYil = yil;
        while (yil > 0)
        {
            basamakToplami += yil % 10;
            yil /= 10;
        }
        return basamakToplami < (orijinalYil / 4);
    }

    private static bool AsalMi(int sayi)
    {
        if (sayi < 2) return false;
        for (int i = 2; i * i <= sayi; i++)
        {
            if (sayi % i == 0) return false;
        }
        return true;
    }

    private static bool ArtikYilMi(int yil)
    {
        return (yil % 4 == 0 && yil % 100 != 0) || (yil % 400 == 0);
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<string> tarihler = ZamanYolculugu.GecerliTarihler();
        Console.WriteLine("Geçerli tarihler:");
        foreach (string tarih in tarihler)
        {
            Console.WriteLine(tarih);
        }
    }
}
