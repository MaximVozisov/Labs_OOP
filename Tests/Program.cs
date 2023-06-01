using System;
using System.Security.Cryptography;

class Program
{
    public static int MinMas(int[] mas, int n)
    {
        int min = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            if (mas[i] < min && mas[i] != 0)
                min = mas[i];
        }
        if (min == int.MaxValue)
        {
            min = 0;
        }
        return min;
    }
    static void Main()
    {
        int[,] A = {  { 0, 2, 3, 2 },
                      { 2, 0, 2, 0 },
                      { 0, 0, 0, 0 },
                      { 0, 2, 1, 0 }  };
        int[,] B = {  { 0, 2, 3, 2 },
                      { 2, 0, 2, 0 },
                      { 0, 0, 0, 0 },
                      { 0, 2, 1, 0 }  };
        int n = 4;
        int[,] C = new int[n, n];

        // Вычисление матрицы C
        int[] temp = new int[n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                for (int k = 0; k < n; k++)
                {
                    if(A[k, j] == 0 || B[i, k] == 0)
                    {
                        temp[k] = int.MaxValue;
                    }
                    else
                        temp[k] = A[k, j] + B[i, k];
                }
                C[i, j] = MinMas(temp, n);
            }
        }

        // Вывод матрицы C
        Console.WriteLine("Матрица C:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(C[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}