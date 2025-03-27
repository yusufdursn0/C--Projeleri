using System;
using System.Data;

class Program
{
    static void Main()
    {
        Console.WriteLine("Bir matematiksel ifade girin:");
        string ifade = Console.ReadLine();

        try
        {
            var sonuc = HesaplaVeIslemSirasi(ifade);
            Console.WriteLine("Sonuç: " + sonuc);
        }
        catch (Exception e)
        {
            Console.WriteLine("Hata: " + e.Message);
        }
    }

    static double HesaplaVeIslemSirasi(string ifade)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("İfade", typeof(string), ifade);
        var islemSirasi = ifade.Split(new char[] { '+', '-', '*', '/', '(', ')', '^' }, StringSplitOptions.RemoveEmptyEntries);

        Console.WriteLine("İşlem sırası:");
        foreach (var item in islemSirasi)
        {
            Console.WriteLine(item);
        }

        return Convert.ToDouble(dt.Compute(ifade, ""));
    }
}
