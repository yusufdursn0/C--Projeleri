using System;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Bir dizi tam sayı girin (boşluk ile ayırın): ");
            int[] dizi = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            Array.Sort(dizi);
            Console.WriteLine("Sıralı dizi: " + string.Join(", ", dizi));

            Console.WriteLine("Aramak istediğiniz sayıyı girin: ");
            int aranan;
            if (!int.TryParse(Console.ReadLine(), out aranan))
            {
                Console.WriteLine("Geçersiz giriş! Lütfen bir tam sayı girin.");
                return;
            }

            bool bulundu = IkiliArama(dizi, aranan);

            if (bulundu)
                Console.WriteLine($"{aranan} dizide bulundu.");
            else
                Console.WriteLine($"{aranan} dizide bulunamadı.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Geçersiz giriş! Lütfen yalnızca tam sayılar girin.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Bir hata oluştu: " + ex.Message);
        }
    }

    static bool IkiliArama(int[] dizi, int aranan)
    {
        int sol = 0, sag = dizi.Length - 1;

        while (sol <= sag)
        {
            int orta = (sol + sag) / 2;

            if (dizi[orta] == aranan)
                return true;
            else if (dizi[orta] < aranan)
                sol = orta + 1;
            else
                sag = orta - 1;
        }

        return false;
    }
}
