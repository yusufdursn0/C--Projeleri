using System;
using System.Collections.Generic;

public class MesajCozucu
{
    public static string SifreCoz(string sifreliMesaj)
    {
        List<int> fibonacci = FibonacciSerisi(sifreliMesaj.Length);
        string cozulmusMesaj = "";

        for (int i = 0; i < sifreliMesaj.Length; i++)
        {
            int asciiDeger = (int)sifreliMesaj[i];
            int modDeger = AsalMi(i + 1) ? 100 : 256;
            int orijinalDeger = asciiDeger % modDeger == 0 ? asciiDeger : asciiDeger + modDeger * fibonacci[i];
            cozulmusMesaj += (char)(orijinalDeger / fibonacci[i]);
        }
        return cozulmusMesaj;
    }

    private static List<int> FibonacciSerisi(int uzunluk)
    {
        List<int> fibonacci = new List<int> { 1, 1 };
        for (int i = 2; i < uzunluk; i++)
        {
            fibonacci.Add(fibonacci[i - 1] + fibonacci[i - 2]);
        }
        return fibonacci;
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
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Şifreli mesajı girin:");
        string sifreliMesaj = Console.ReadLine();

        string cozulmusMesaj = MesajCozucu.SifreCoz(sifreliMesaj);
        Console.WriteLine("Çözülmüş mesaj:");
        Console.WriteLine(cozulmusMesaj);
    }
}
