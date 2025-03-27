using System;
using System.Collections.Generic;

class Labirent
{
    static void Main()
    {
        // Kullanıcıdan labirent boyutunu al
        Console.Write("Labirent boyutunu girin (N): ");
        int N = int.Parse(Console.ReadLine());

        // Labirenti kullanıcıdan al
        int[,] labirent = new int[N, N];
        Console.WriteLine("Labirenti satır satır girin. Sadece 1 (yol) ve 0 (duvar/tuzak) girebilirsiniz.");
        for (int i = 0; i < N; i++)
        {
            while (true)
            {
                Console.Write($"Satır {i + 1}: ");
                string[] rowInput = Console.ReadLine().Split(' ');
                if (rowInput.Length != N || !IsValidRow(rowInput))
                {
                    Console.WriteLine("Geçersiz giriş! Sadece 1 ve 0 değerleri kabul edilir.");
                    continue;
                }

                for (int j = 0; j < N; j++)
                {
                    labirent[i, j] = int.Parse(rowInput[j]);
                }
                break; // Geçerli satır girildiyse döngüden çık
            }
        }

        int result = EnKisaYolBul(labirent, N);

        if (result != -1)
        {
            Console.WriteLine($"Hazineye en kısa yol {result} adım.");
        }
        else
        {
            Console.WriteLine("Yol Yok");
        }
    }

    // Sadece 1 ve 0 içeren geçerli bir satır olup olmadığını kontrol et
    static bool IsValidRow(string[] row)
    {
        foreach (var value in row)
        {
            if (value != "1" && value != "0")
            {
                return false;
            }
        }
        return true;
    }

    // Labirentte en kısa yolu bulmak için BFS kullan
    static int EnKisaYolBul(int[,] labirent, int N)
    {
        // Yön vektörleri (yukarı, aşağı, sol, sağ)
        int[] dX = { -1, 1, 0, 0 };
        int[] dY = { 0, 0, -1, 1 };

        // Ziyaret edilen düğümleri takip etmek için
        bool[,] visited = new bool[N, N];
        visited[0, 0] = true;

        // BFS için bir kuyruk oluştur (x, y, adım sayısı)
        Queue<(int, int, int)> queue = new Queue<(int, int, int)>();
        queue.Enqueue((0, 0, 1)); // (0, 0) başlangıç noktası, 1 adım

        // BFS döngüsü
        while (queue.Count > 0)
        {
            var (x, y, steps) = queue.Dequeue();

            // Eğer hazineye ulaştıysak
            if (x == N - 1 && y == N - 1)
            {
                return steps;
            }

            // 4 komşu hücreyi kontrol et (yukarı, aşağı, sol, sağ)
            for (int i = 0; i < 4; i++)
            {
                int newX = x + dX[i];
                int newY = y + dY[i];

                // Geçerli bir hücre mi, ziyaret edilmemiş mi ve geçilebilir mi (1 mi)?
                if (newX >= 0 && newX < N && newY >= 0 && newY < N && !visited[newX, newY] && labirent[newX, newY] == 1)
                {
                    visited[newX, newY] = true;
                    queue.Enqueue((newX, newY, steps + 1));
                }
            }
        }

        // Hazineye ulaşılamadıysa
        return -1;
    }
}
