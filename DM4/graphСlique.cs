﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace DM4
{
    internal class graphСlique
    {
        private int j;
        private int V; // количество вершин в графе
        private bool[][] graphBool; // граф булевых переменных

        // конструктор
        public graphСlique(int v)
        {
            V = v;
            graphBool = new bool[V][];
            for (int i = 0; i < V; i++)
            {
                graphBool[i] = new bool[v];
            }
            if (v == 5)
            {
                graphBool = new bool[][]
                {
                    new bool[] { false, true, true, true, true },
                    new bool[] { true, false, true, false, false },
                    new bool[] { true, true, false, true, true },
                    new bool[] { true, false, true, false, true },
                    new bool[] { true, false, true, true, false }
                };
            }
            if (v == 4)
            {
                graphBool = new bool[][]
                {
                    new bool[] { false, true, true, true },
                    new bool[] { true, false, true, false },
                    new bool[] { true, true, false, true },
                    new bool[] { true, false, true, false }
                };
            }
        }

        // метод проверки, являются ли все вершины в clique смежными друг с другом
        private bool IsClique(bool[][] graph, int[] subset, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    if (!graph[subset[i]][subset[j]])
                        return false;
                }
            }
            return true;
        }

        private void FindClK(bool[][] graph, int subsetSize, int[] subset, int k)
        {
            if (subsetSize == k)
            {
                if (IsClique(graph, subset, k))
                {
                    j = subset.Length;
                }
                return;
            }


            int last = subsetSize == 0 ? -1 : subset[subsetSize - 1];
            for (int i = last + 1; i < V; i++)
            {
                subset[subsetSize] = i;
                FindClK(graph, subsetSize + 1, subset, k);
            }
        }

        // метод для поиска клики в графе
        private void FindCliques(bool[][] graph, int subsetSize, int[] subset, int k)
        {
            if (subsetSize == k)
            {
                if (IsClique(graph, subset, k))
                {
                    Console.Write("Клика: ");
                    foreach (int v in subset)
                    {
                        Console.Write(v + 1 + " ");
                    }
                    Console.WriteLine();
                }
                return;
            }
            

            int last = subsetSize == 0 ? -1 : subset[subsetSize - 1];
            for (int i = last + 1; i < V; i++)
            {
                subset[subsetSize] = i;
                FindCliques(graph, subsetSize + 1, subset, k);
            }
        }

        //Создание таблицы графа
        public void CreateGraphTable()
        {
            V = Program.GetInt("Введите количество вершин: ", "Неверный ввод, повторите попытку.\n", (int num) => num >= 0);
            graphBool = new bool[V][];
            for (int i = 0; i < V; i++)
            {
                graphBool[i] = new bool[V];
                for (int j = 0; j < graphBool[i].Length; ++j)
                {
                    int temp = Program.GetInt($"Введи путь {i + 1} --> {j + 1}: ", "Неверный ввод, повторите попытку.\n", (int num) => num >= 0);
                    if (temp > 0)
                    {
                        graphBool[i][j] = true;
                    }
                    else
                    {
                        graphBool[i][j] = false;
                    }
                }
            }
        }

        //Вывод таблицы графа
        public void PrintGraphTable()
        {
            if (V <= 0)
            {
                Program.ColorDisplay("Граф не создан\n", ConsoleColor.Red);
            }
            else
            {
                Console.WriteLine("Таблица графа: ");
                for (int i = 0; i < V; i++)
                {
                    for (int j = 0; j < V; j++)
                    {
                        Console.Write(graphBool[i][j] + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }

        public void SearchCliques()
        {
            if (V > 0)
            {
                for (int t = 0; t <= V; t++)
                {
                    int[] subset = new int[t];
                    FindClK(graphBool, 0, subset, t);
                }
                int[] subset1 = new int[j];
                FindCliques(graphBool, 0, subset1, j);
            }
            else
            {
                Program.ColorDisplay("Граф не создан\n", ConsoleColor.Red);
            }
        }
    }
}
