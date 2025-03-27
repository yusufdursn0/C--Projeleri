using System;

public class Madenciler
{
    public static int EnAzEnerji(int[,] enerji)
    {
        int N = enerji.GetLength(0);
        int[,] dp = new int[N, N];
        dp[0, 0] = enerji[0, 0];

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (i > 0) dp[i, j] = Math.Min(dp[i, j], dp[i - 1, j] + enerji[i, j]);
                if (j > 0) dp[i, j] = Math.Min(dp[i, j], dp[i, j - 1] + enerji[i, j]);
                if (i > 0 && j > 0) dp[i, j] = Math.Min(dp[i, j], dp[i - 1, j - 1] + enerji[i, j]);
            }
        }
        return dp[N - 1, N - 1];
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Matris boyutunu giriniz (N):");
        int N = int.Parse(Console.ReadLine());

        int[,] enerji = new int[N, N];
        Console.WriteLine("Enerji değerlerini giriniz:");

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write($"enerji[{i},{j}]: ");
                enerji[i, j] = int.Parse(Console.ReadLine());
            }
        }

        int minimumEnerji = Madenciler.EnAzEnerji(enerji);
        Console.WriteLine("En az enerji harcayan yolun maliyeti: " + minimumEnerji);
    }
}
