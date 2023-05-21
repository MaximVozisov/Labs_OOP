using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DM4
{
    internal class GraphTable
    {
        private int verticesCount;
        private List<int>[] adjList;
        private int[,] graph;
        public GraphTable(int vertices)
        {
            verticesCount = vertices;
            graph = new int[vertices, vertices];
            adjList = new List<int>[vertices];

            for (var i = 0; i < verticesCount; i++)
            {
                adjList[i] = new List<int>();
            }
        }

        //Добавление пути
        public void AddEdge(int v, int w)
        {
            adjList[v].Add(w);
        }

        //Топологическая сортировка
        public void TopologicalSort()
        {
            Conversion();
            var inDegree = new int[verticesCount];
            for (var i = 0; i < verticesCount; i++)
            {
                inDegree[i] = 0;
            }

            foreach (var v in adjList.SelectMany(item => item))
            {
                inDegree[v]++;
            }

            var queue = new Queue<int>();
            for (var i = 0; i < verticesCount; i++)
            {
                if (inDegree[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            var level = 0;
            while (queue.Count() != 0)
            {
                var itemsCount = queue.Count();
                for (var i = 0; i < itemsCount; i++)
                {
                    var v = queue.Dequeue();
                    Console.Write("{0} ({1}) ", v, level);

                    foreach (var adj in adjList[v])
                    {
                        inDegree[adj]--;
                        if (inDegree[adj] == 0)
                        {
                            queue.Enqueue(adj);
                        }
                    }
                }
                level++;
            }
        }

        //Создание таблицы графа
        public void CreateGraphTable()
        {
            verticesCount = Program.GetInt("Введите количество вершин: ", "Неверный ввод, повторите попытку.\n", (int num) => num >= 0);
            graph = new int[verticesCount, verticesCount];
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

        //Конвертирование таблицы графа в граф списком
        public void Conversion()
        {
            for (int i = 0;i < verticesCount;i++)
            {
                for (int j = 0;j < verticesCount;j++)
                {
                    if (graph[i, j] != 0)
                    {
                        AddEdge(i, j);
                    }
                }
            }
        }
    }
}