using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DM4
{
    internal class GraphTable
    {
        private int verticesCount;
        private int[,] graph;
        private int[] count;
        public GraphTable(int vertices)
        {
            verticesCount = vertices;
            graph = new int[vertices, vertices];
            count = new int[vertices];
            for (int i = 0; i < verticesCount; i++)
            {
                count[i] = i + 1;
            }
            if (vertices == 4)
            {
                int[,] adjacencyMatrix = {  { 0, 2, 3, 2 },
                                            { 2, 0, 2, 0 },
                                            { 0, 0, 0, 0 },
                                            { 0, 2, 1, 0 }  };
                graph = adjacencyMatrix;
            }
        }

        //Топологическая отрисовка уровня
        private void TopologicalWriteLevel(int level)
        {
            int[] temp = new int[count.Length];
            int ji = -1;
            foreach (int j in count)
            {
                ji++;
                bool isZero = true;
                foreach (int i in count)
                {
                    if (graph[i - 1, j - 1] != 0)
                    {
                        isZero = false;
                        break;
                    }
                }
                if (isZero)
                {
                    temp[ji] = j;
                    Console.WriteLine("{0}({1}) ", j, level);
                }
            }
            DelLevel(temp);
        }

        //Цикл топологической отрисовки
        public void TopologicalSort()
        {
            int level = 0;
            while (count.Length > 0)
            {
                TopologicalWriteLevel(level);
                level++;
            }
            count = new int[verticesCount];
            for (int i = 0; i < verticesCount; i++)
            {
                count[i] = i + 1;
            }
        }

        //Удаление нулевых столбцов
        private void DelLevel(int[] temp)
        {
            for (int i = 0;i < temp.Length;i++)
            {
                if (temp[i] != 0)
                {
                    DelEl(temp[i]);
                }
            }
        }

        //Удаление элемента массива по ключу
        private void DelEl(int el)
        {
            int[] countNew = new int[count.Length - 1];
            for (int i = 0, j = 0; i < count.Length; i++)
            {
                if (count[i] != el)
                {
                    countNew[j] = count[i];
                    j++;
                }
            }
            count = new int[countNew.Length];
            for (int i = 0;i < countNew.Length;i++)
            {
                count[i] = countNew[i];
            }
        }

        //Создание таблицы графа
        public void CreateGraphTable()
        {
            verticesCount = Program.GetInt("Введите количество вершин: ", "Неверный ввод, повторите попытку.\n", (int num) => num >= 0);
            graph = new int[verticesCount, verticesCount];
            count = new int[verticesCount];
            for (int i = 0; i < verticesCount; i++)
            {
                count[i] = i + 1;
            }
            for (int i = 0; i < verticesCount; i++)
            {
                for (int j = 0; j < verticesCount; j++)
                {
                    graph[i, j] = Program.GetInt($"Введи путь {i + 1} --> {j + 1}: ", "Неверный ввод, повторите попытку.\n", (int num) => num >= 0);
                }
            }
        }
        
        //Вывод таблицы графа
        public void PrintGraphTable()
        {
            if (verticesCount <= 0)
            {
                Program.ColorDisplay("Граф не создан\n", ConsoleColor.Red);
            }
            else
            {
                Console.WriteLine("Таблица графа: ");
                for (int i = 0; i < verticesCount; i++)
                {
                    for (int j = 0; j < verticesCount; j++)
                    {
                        Console.Write(graph[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }

        public int[,] SumMatrix(int[,] matrix, int[,] graph)
        {
            int[,] C = new int[verticesCount, verticesCount];
            int[] temp = new int[verticesCount];
            for (int i = 0; i < verticesCount; i++)
            {
                for (int j = 0; j < verticesCount; j++)
                {
                    for (int k = 0; k < verticesCount; k++)
                    {
                        if (matrix[k, j] == 0 || graph[i, k] == 0)
                        {
                            temp[k] = int.MaxValue;
                        }
                        else
                            temp[k] = matrix[k, j] + graph[i, k];
                    }
                    C[i, j] = MinMas(temp, verticesCount);
                }
            }
            return C;
        }

        private int MinMas(int[] mas, int n)
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

        public void AlgShimbella()
        {
            int k = Program.GetInt("Введите количество ребер: ", "Несуществующая команда, повторите ввод.\n", (int num) => num >= 0) - 1;
            int[,] matrix = graph;
            for (int i = 0; i < k; i++)
            {
                matrix = SumMatrix(matrix, graph);
            }
            for (int i = 0; i < verticesCount; i++)
            {
                for (int j = 0; j < verticesCount; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}