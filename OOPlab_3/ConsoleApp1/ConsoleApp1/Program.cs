using System;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Random random = new Random();

        Console.WriteLine("Введіть кількість рядків масиву (n):");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Введіть кількість стовпців масиву (m):");
        int m = int.Parse(Console.ReadLine());

        double[,] array = new double[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                array[i, j] = Math.Round(-12.3 + random.NextDouble() * (126.3 - (-12.3)), 1);
            }
        }

        Console.WriteLine("Початковий масив:");
        PrintArray(array);

        // Завдання 1: Знайти окремо суму елементів кожного стовпця та визначити серед них найбільшу
        double[] columnSums = new double[m];
        for (int j = 0; j < m; j++)
        {
            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += array[i, j];
            }
            columnSums[j] = sum;
        }

        double maxColumnSum = columnSums.Max();
        Console.WriteLine($"\nСуми елементів кожного стовпця: {string.Join(", ", columnSums)}");
        Console.WriteLine($"Найбільша сума серед стовпців: {maxColumnSum}");

        // Завдання 2: Поміняти місцями 1 та останній рядки, 2 та передостанній і так далі
        for (int i = 0; i < n / 2; i++)
        {
            for (int j = 0; j < m; j++)
            {
                double temp = array[i, j];
                array[i, j] = array[n - 1 - i, j];
                array[n - 1 - i, j] = temp;
            }
        }

        Console.WriteLine("\nМасив після зміни місцями рядків:");
        PrintArray(array);
    }

    static void PrintArray(double[,] array)
    {
        int rows = array.GetLength(0);
        int columns = array.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write($"{array[i, j],6} ");
            }
            Console.WriteLine();
        }
    }
}
