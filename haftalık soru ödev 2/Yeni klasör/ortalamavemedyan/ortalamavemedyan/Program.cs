using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> sayilar = new List<int>();
        int sayi;

        Console.WriteLine("Pozitif tam sayılar girin (0 ile bitirin):");
        while (true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out sayi))
            {
                if (sayi == 0) break;
                if (sayi > 0)
                    sayilar.Add(sayi);
                else
                    Console.WriteLine("Lütfen pozitif bir tam sayı girin.");
            }
            else
            {
                Console.WriteLine("Geçersiz giriş! Lütfen bir tam sayı girin.");
            }
        }

        if (sayilar.Count > 0)
        {
            double ortalama = sayilar.Average();
            double medyan = MedyanHesapla(sayilar);

            Console.WriteLine("Ortalama: " + ortalama);
            Console.WriteLine("Medyan: " + medyan);
        }
        else
        {
            Console.WriteLine("Hiç sayı girilmedi.");
        }
    }

    static double MedyanHesapla(List<int> sayilar)
    {
        sayilar.Sort();
        int n = sayilar.Count;

        if (n % 2 == 1)
            return sayilar[n / 2];
        else
            return (sayilar[(n - 1) / 2] + sayilar[n / 2]) / 2.0;
    }
}
