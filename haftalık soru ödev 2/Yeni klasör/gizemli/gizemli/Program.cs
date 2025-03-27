using System;
using System.Collections.Generic;
using System.Data;

public class TapinakKapisi
{
    private static readonly char[] operators = { '+', '-', '*', '/' };

    public static void KapıyıAç(int[] sayilar)
    {
        string sonuc = KapıKilidiÇöz(sayilar, 0, sayilar[0].ToString());
        if (sonuc == null)
        {
            Console.WriteLine("Geçerli bir çözüm bulunamadı.");
        }
        else
        {
            Console.WriteLine("Kapıyı açan çözüm: " + sonuc);
        }
    }

    private static string KapıKilidiÇöz(int[] sayilar, int index, string ifade)
    {
        if (index == sayilar.Length - 1)
        {
            if (Değerlendir(ifade) > 0)
            {
                return ifade;
            }
            return null;
        }

        for (int i = 0; i < operators.Length; i++)
        {
            char op = operators[i];
            string yeniIfade = ifade + op + sayilar[index + 1];
            string sonuc = KapıKilidiÇöz(sayilar, index + 1, yeniIfade);
            if (sonuc != null)
            {
                return sonuc;
            }
        }

        return null;
    }

    private static double Değerlendir(string ifade)
    {
        try
        {
            DataTable table = new DataTable();
            table.Columns.Add("expression", typeof(string), ifade);
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            double sonuc = double.Parse((string)row["expression"]);
            return sonuc;
        }
        catch
        {
            return double.MinValue;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] sayilar = { 3, 5, 7, 2 }; // Örnek sayı dizisi
        TapinakKapisi.KapıyıAç(sayilar);
    }
}
