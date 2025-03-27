using System;
using System.Collections.Generic;

class TechCityRescue
{
    static Random random = new Random();

    static void Main()
    {
        // Kullanıcıdan grid boyutunu al
        Console.Write("Grid boyutunu girin (N): ");
        int N = int.Parse(Console.ReadLine());

        // Grid'i kullanıcıdan al ve sadece 1 ve 0 içermesi gerektiğini kontrol et
        int[,] grid = new int[N, N];

        Console.WriteLine("Grid'i satır satır girin. Sadece 1 ve 0 girebilirsiniz.");
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
                    grid[i, j] = int.Parse(rowInput[j]);
                }
                break; // Geçerli satır girildiyse döngüden çık
            }
        }

        // Robot sayısı
        int robotCount = 3;

        // Ziyaret edilen düğümleri takip eden visited matrisi
        bool[,] visited = new bool[grid.GetLength(0), grid.GetLength(1)];

        // Her robot için başlangıç pozisyonlarını rastgele seç
        List<(int, int)> robotStartPositions = new List<(int, int)>();

        for (int i = 0; i < robotCount; i++)
        {
            (int, int) startPosition = GetRandomStartPosition(grid, visited);
            robotStartPositions.Add(startPosition);
            Console.WriteLine($"Robot {i + 1} başlangıç pozisyonu: ({startPosition.Item1}, {startPosition.Item2})");
        }

        // Her robotun kurtarabileceği düğümleri bul
        for (int i = 0; i < robotStartPositions.Count; i++)
        {
            var startPos = robotStartPositions[i];
            int rescued = RescueNodes(grid, visited, startPos.Item1, startPos.Item2, i + 1);
            Console.WriteLine($"Robot {i + 1} {rescued} düğüm kurtardı.");
        }

        Console.WriteLine("Tüm robotlar işlem yaptı.");
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

    // Rastgele bir başlangıç pozisyonu seçen fonksiyon
    static (int, int) GetRandomStartPosition(int[,] grid, bool[,] visited)
    {
        int x, y;
        do
        {
            x = random.Next(0, grid.GetLength(0));
            y = random.Next(0, grid.GetLength(1));
        } while (grid[x, y] == 0 || visited[x, y]); // Zarar görmemiş ve ziyaret edilmemiş olmalı

        return (x, y);
    }

    // Robotun komşu düğümlerini kurtaran fonksiyon
    static int RescueNodes(int[,] grid, bool[,] visited, int x, int y, int robotNumber)
    {
        // Geçersiz bir düğüme gitmemek için kontrol
        if (x < 0 || x >= grid.GetLength(0) || y < 0 || y >= grid.GetLength(1) || visited[x, y] || grid[x, y] == 0)
        {
            return 0;
        }

        // Ziyaret edilen düğümü işaretle
        visited[x, y] = true;
        int rescued = 1; // Bu düğüm kurtarıldı

        Console.WriteLine($"Robot {robotNumber} ({x}, {y}) düğümünü kurtardı.");

        // Komşu düğümlere git (yukarı, aşağı, sağ, sol)
        rescued += RescueNodes(grid, visited, x - 1, y, robotNumber); // Yukarı
        rescued += RescueNodes(grid, visited, x + 1, y, robotNumber); // Aşağı
        rescued += RescueNodes(grid, visited, x, y - 1, robotNumber); // Sol
        rescued += RescueNodes(grid, visited, x, y + 1, robotNumber); // Sağ

        return rescued;
    }
}
