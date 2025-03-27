using System;

class MatrixMultiplication
{
    static void Main()
    {
        Console.Write("Matris boyutunu girin (N): ");
        int n = int.Parse(Console.ReadLine());

        // Matrislerin tanımlanması
        int[,] matrix1 = new int[n, n];
        int[,] matrix2 = new int[n, n];
        int[,] resultMatrix = new int[n, n];

        // Birinci matrisi kullanıcıdan alma
        Console.WriteLine("Birinci matrisi girin:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"matrix1[{i},{j}] = ");
                matrix1[i, j] = int.Parse(Console.ReadLine());
            }
        }

        // İkinci matrisi kullanıcıdan alma
        Console.WriteLine("İkinci matrisi girin:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"matrix2[{i},{j}] = ");
                matrix2[i, j] = int.Parse(Console.ReadLine());
            }
        }

        // Matris çarpımının yapılması
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                resultMatrix[i, j] = 0; // Başlangıç değeri 0
                for (int k = 0; k < n; k++)
                {
                    resultMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }

        // Sonuç matrisinin ekrana yazdırılması
        Console.WriteLine("Matrislerin çarpım sonucu:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(resultMatrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
