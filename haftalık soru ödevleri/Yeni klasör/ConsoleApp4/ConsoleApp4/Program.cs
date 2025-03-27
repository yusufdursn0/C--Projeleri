using System;

class PrimeSum
{
    static void Main()
    {
        Console.Write("N sayısını girin: ");
        int N = int.Parse(Console.ReadLine());

        int sum = 0;

        // 2'den N'ye kadar olan sayıları kontrol et
        for (int i = 2; i <= N; i++)
        {
            if (IsPrime(i))
            {
                sum += i;
            }
        }

        Console.WriteLine($"N'ye kadar olan asal sayıların toplamı: {sum}");
    }

    // Asal sayı kontrolü yapan fonksiyon
    static bool IsPrime(int number)
    {
        if (number < 2) return false;

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }
        return true;
    }
}
