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
        public int[,] graph;
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
    }
}