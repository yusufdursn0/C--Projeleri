using System;

class SpiralMatrix
{
    static void Main()
    {
        Console.Write("Matrisin boyutunu girin: ");
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];

        int value = 1;
        int left = 0, right = n - 1;
        int top = 0, bottom = n - 1;

        while (left <= right && top <= bottom)
        {
            // Top row
            for (int i = left; i <= right; i++)
            {
                matrix[top, i] = value++;
            }
            top++;

            // Right column
            for (int i = top; i <= bottom; i++)
            {
                matrix[i, right] = value++;
            }
            right--;

            // Bottom row
            if (top <= bottom)
            {
                for (int i = right; i >= left; i--)
                {
                    matrix[bottom, i] = value++;
                }
                bottom--;
            }

            // Left column
            if (left <= right)
            {
                for (int i = bottom; i >= top; i--)
                {
                    matrix[i, left] = value++;
                }
                left++;
            }
        }

        // Matrisin ekrana yazdırılması
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j].ToString().PadLeft(4));
            }
            Console.WriteLine();
        }
    }
}
