using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> sayilar = new List<int>();
        int sayi;

        Console.WriteLine("Bir dizi tam sayı girin (0 ile bitirin):");
        while ((sayi = int.Parse(Console.ReadLine())) != 0)
        {
            sayilar.Add(sayi);
        }

        List<string> gruplar = ArdısıkGruplarıBul(sayilar);

        Console.WriteLine("Ardışık gruplar:");
        foreach (var grup in gruplar)
        {
            Console.WriteLine(grup);
        }
    }

    static List<string> ArdısıkGruplarıBul(List<int> sayilar)
    {
        List<string> gruplar = new List<string>();
        sayilar.Sort();

        int baslangic = sayilar[0], onceki = sayilar[0];

        for (int i = 1; i < sayilar.Count; i++)
        {
            if (sayilar[i] != onceki + 1)
            {
                gruplar.Add(baslangic == onceki ? baslangic.ToString() : $"{baslangic}-{onceki}");
                baslangic = sayilar[i];
            }
            onceki = sayilar[i];
        }

        gruplar.Add(baslangic == onceki ? baslangic.ToString() : $"{baslangic}-{onceki}");
        return gruplar;
    }
}
