using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DM4
{
    internal class ImplementationShimbella
    {
        private int[][] adjMatrix;
        private int[] distance;
        private bool[] visited;
        private int size;

        public ImplementationShimbella(int vertices)
        {
            int[][] adjMatrix = new int[vertices][];
            for (int i  = 0; i < vertices; i++)
            {
                adjMatrix[i] = new int[vertices];
            }
            size = vertices;
            distance = new int[size];
            visited = new bool[size];
        }

        //выбор следующей вершины для поиска кратчайшего пути
        private int GetNextVertex()
        {
            int minDist = int.MaxValue; // присвоение максимального значения
            int vertex = -1; // пока что -1 - ошибка
            for (int i = 0; i < distance.Length; ++i) //проходимся по всему массиву дистанция до других точек
            {
                if (!visited[i] && distance[i] < minDist) // если она не посещена и дистанция до данной вершины меньше чем минимальный
                {
                    minDist = distance[i];
                    vertex = i;
                }
            }
            return vertex;
        }

        public int[] FindShortestPath(int start)
        {
            for (int i = 0; i < distance.Length; ++i) // подготовка
            {
                distance[i] = int.MaxValue;
                visited[i] = false;
            }
            distance[start] = 0; // дистанция от вершины, колторой мы ищем до нее же = 0

            for (int i = 0; i < distance.Length - 1; ++i) // вычисляем расстояния от заданной вершины (start) до других
            {
                int current = GetNextVertex(); // выбираем вершину с наименьшим расстоянием из набора непосещенных вершин
                visited[current] = true;

                for (int j = 0; j < adjMatrix[current].Length; ++j) // обновление расстояний до всех вершин
                {
                    if (adjMatrix[current][j] != 0 && !visited[j])
                    {
                        int newDistance = distance[current] + adjMatrix[current][j];
                        if (newDistance < distance[j])
                        {
                            distance[j] = newDistance;
                        }
                    }
                }
            }
            return distance;
        }

        //Создание таблицы графа
        public void CreateGraphTable()
        {
            int vertices = Program.GetInt("Введите количество вершин: ", "Неверный ввод, повторите попытку.\n", (int num) => num >= 0);
            adjMatrix = new int[vertices][];
            for (int i = 0; i < vertices; i++)
            {
                adjMatrix[i] = new int[vertices];
                for (int j = 0;j < adjMatrix[i].Length; ++j)
                {
                    adjMatrix[i][j] = Program.GetInt($"Введи путь {i + 1} --> {j + 1}: ", "Неверный ввод, повторите попытку.\n", (int num) => num >= 0);
                }
            }
            size = vertices;
            distance = new int[size];
            visited = new bool[size];
        }

        //Вывод таблицы графа
        public void PrintGraphTable()
        {
            if (size <= 0)
            {
                Program.ColorDisplay("Граф не создан\n", ConsoleColor.Red);
            }
            else
            {
                Console.WriteLine("Таблица графа: ");
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        Console.Write(adjMatrix[i][j] + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }

        public void StartAlgShimbella()
        {
            if (size == 0)
            {
                Program.ColorDisplay("Граф не создан\n", ConsoleColor.Red);
            }
            else
            {
                int vertices = Program.GetInt($"Введите номер вершины, из которой надо найти кратчайший путь в другие вершины: ", "Такой вершины нет!\n", (int num) => num >= 1 && num <= size);
                int[] distances = FindShortestPath(vertices - 1);
                for (int i = 0; i < distances.Length; ++i)
                {
                    Console.WriteLine("Дистанция из {0} to {1} is {2}", vertices, i + 1, distances[i]);
                }
            }
        }
    }
}
