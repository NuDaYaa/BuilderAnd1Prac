using System;

class Program
{
    static void Main()
    {
        int n = 5; 
        int m = 6; 
        double[,] matrix = GenerateRandomMatrix(n, m);
        PrintMatrix(matrix);
        FindNegativeColumns(matrix);
    }

    static double[,] GenerateRandomMatrix(int rows, int cols)
    {
        Random rand = new Random();
        double[,] matrix = new double[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = rand.NextDouble() * 20 - 10; 
            }
        }
        return matrix;
    }

    static void PrintMatrix(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        Console.WriteLine("Сгенерированная матрица:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{matrix[i, j],8:F2} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void FindNegativeColumns(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        Console.WriteLine("Столбцы, содержащие только отрицательные элементы:");
        bool found = false;

        for (int j = 0; j < cols; j++)
        {
            bool allNegative = true;

            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, j] >= 0)
                {
                    allNegative = false;
                    break;
                }
            }

            if (allNegative)
            {
                Console.WriteLine($"Столбец {j + 1}");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Нет таких столбцов.");
        }
    }
}
