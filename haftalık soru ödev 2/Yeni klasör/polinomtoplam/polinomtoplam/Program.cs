using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string giris1, giris2;

        while (true)
        {
            Console.WriteLine("Birinci polinomu girin (örnek: 2x^2 + 3x - 5): ");
            giris1 = Console.ReadLine();
            if (giris1.ToLower() == "exit") break;

            Console.WriteLine("İkinci polinomu girin (örnek: x^2 - 4): ");
            giris2 = Console.ReadLine();
            if (giris2.ToLower() == "exit") break;

            Dictionary<int, int> polinom1 = PolinomOlustur(giris1);
            Dictionary<int, int> polinom2 = PolinomOlustur(giris2);

            var toplam = PolinomTopla(polinom1, polinom2);
            var fark = PolinomCikar(polinom1, polinom2);

            Console.WriteLine("Toplam: " + PolinomYazdir(toplam));
            Console.WriteLine("Fark: " + PolinomYazdir(fark));
        }
    }

    static Dictionary<int, int> PolinomOlustur(string polinom)
    {
        Dictionary<int, int> polinomDict = new Dictionary<int, int>();

        // "+" ve "-" işaretine göre bölüyoruz. "-" işaretini koruyarak negatif terimleri ayırıyoruz.
        var terimler = polinom.Replace("-", "+-").Split(new[] { '+' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var terim in terimler)
        {
            int katsayi = 0, us = 0;
            string[] bol;

            if (terim.Contains("x^"))
            {
                bol = terim.Split(new[] { "x^" }, StringSplitOptions.RemoveEmptyEntries);
                katsayi = bol[0] == "-" ? -1 : int.Parse(bol[0]);
                us = int.Parse(bol[1]);
            }
            else if (terim.Contains("x"))
            {
                bol = terim.Split(new[] { "x" }, StringSplitOptions.RemoveEmptyEntries);
                katsayi = bol.Length > 0 ? int.Parse(bol[0]) : 1;
                if (terim.StartsWith("-")) katsayi = -1;
                us = 1;
            }
            else
            {
                katsayi = int.Parse(terim);
                us = 0;
            }

            if (polinomDict.ContainsKey(us))
                polinomDict[us] += katsayi;
            else
                polinomDict.Add(us, katsayi);
        }

        return polinomDict;
    }

    static Dictionary<int, int> PolinomTopla(Dictionary<int, int> p1, Dictionary<int, int> p2)
    {
        Dictionary<int, int> sonuc = new Dictionary<int, int>(p1);

        foreach (var item in p2)
        {
            if (sonuc.ContainsKey(item.Key))
                sonuc[item.Key] += item.Value;
            else
                sonuc[item.Key] = item.Value;
        }

        return sonuc;
    }

    static Dictionary<int, int> PolinomCikar(Dictionary<int, int> p1, Dictionary<int, int> p2)
    {
        Dictionary<int, int> sonuc = new Dictionary<int, int>(p1);

        foreach (var item in p2)
        {
            if (sonuc.ContainsKey(item.Key))
                sonuc[item.Key] -= item.Value;
            else
                sonuc[item.Key] = -item.Value;
        }

        return sonuc;
    }

    static string PolinomYazdir(Dictionary<int, int> polinom)
    {
        var terimler = polinom.OrderByDescending(x => x.Key)
            .Select(x => x.Key == 0 ? $"{x.Value}" :
                          x.Key == 1 ? $"{x.Value}x" :
                          $"{x.Value}x^{x.Key}");

        return string.Join(" + ", terimler).Replace("+ -", "- ");
    }
}
