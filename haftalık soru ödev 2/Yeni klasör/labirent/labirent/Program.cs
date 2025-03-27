using System;
using System.Collections.Generic;

public class Labirent
{
    public static string LabirentiCoz(int M, int N)
    {
        bool[,] ziyaretEdildi = new bool[M, N];
        return DFS(0, 0, M, N, ziyaretEdildi) ? "Şehre ulaşıldı!" : "Şehir kayboldu!";
    }

    private static bool DFS(int x, int y, int M, int N, bool[,] ziyaretEdildi)
    {
        if (x == M - 1 && y == N - 1) return true;
        if (x < 0 || x >= M || y < 0 || y >= N || ziyaretEdildi[x, y] || !KapiAcilabilir(x, y)) return false;

        ziyaretEdildi[x, y] = true;
        bool sonuc = DFS(x + 1, y, M, N, ziyaretEdildi) ||
                     DFS(x, y + 1, M, N, ziyaretEdildi) ||
                     DFS(x + 1, y + 1, M, N, ziyaretEdildi);
        ziyaretEdildi[x, y] = false;
        return sonuc;
    }

    private static bool KapiAcilabilir(int x, int y)
    {
        return AsalMi(x / 10) && AsalMi(x % 10) && AsalMi(y / 10) && AsalMi(y % 10) && (x + y) % (x * y) == 0;
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
        Console.WriteLine("Labirent boyutlarını giriniz (M N):");
        int M = int.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());

        string sonuc = Labirent.LabirentiCoz(M, N);
        Console.WriteLine(sonuc);
    }
}
