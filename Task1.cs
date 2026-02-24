using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DZ_AISD
{
    internal class Task1
    {
        //Ближайший меньший справа
        //Условие задачи
        //Дан массив целых чисел. Для каждого элемента нужно найти первый элемент справа,
        //который МЕНЬШЕ текущего.Если такого элемента нет, пишем -1.
        static void Main(string[] args)
        {
            int[][] tests = 
            {
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { 5, 4, 3, 2, 1 },
                new int[] { 1, 1, 1, 1, 1 },
                new int[] { 3 },
                new int[] { }
            };

            for (int i = 0; i < tests.Length; i++)
            {
                int[] res1 = Simple_Solution(tests[i]);
                Console.Write("Простое решение:    ");
                for (int j = 0; j < res1.Length; j++)
                {
                    Console.Write(res1[j] + " ");
                }
                Console.WriteLine();
                int[] res2 = BetterSolution(tests[i]);
                Console.Write("Улучшенное решение: ");
                for (int j = 0; j < res2.Length; j++)
                {
                    Console.Write(res2[j] + " ");
                }
                Console.WriteLine();
                Console.WriteLine();

            }
            int[][] tests_2 =
            {
                new int[] { 1, 2, 3, 1, 2, 3, 4, 5 },
                new int[] { 1, 1, 1, 1, 1 },
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { 1, 2, 1, 2, 3, 4, 5, 3 },
                new int[] { 1, 2, 3, 2, 1, 4, 5, 6, 7, 8 },
                new int[] { }
            };

            //Task 2
            //Самая длинная подпоследовательность без повторяющихся элементов
            //Условие задачи
            //Найти длину самой длинной непрерывной подпоследовательности(подмассива),
            //в которой все элементы уникальны(нет повторений).
            for (int i = 0; i < tests_2.Length; i++)
            {
                int len = SolutionTask2(tests_2[i]);
                Console.Write("Max len: " + len);
                Console.WriteLine();
            }
        }
        static int[] Simple_Solution(int[] arr)
        {
            int n = arr.Length;
            int[] result = new int[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = -1;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[i])
                    {
                        result[i] = arr[j];
                        break;
                    }
                }
            }
            return result;
        }

        static int[] BetterSolution(int[] arr)
        {
            int n = arr.Length;
            int[] result = new int[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = -1;
            }

            int[] stack = new int[n];
            int stackTop = -1;
            for (int i = 0; i < n; i++)
            {
                while (stackTop >= 0 && arr[i] < arr[stack[stackTop]])
                {
                    int idx = stack[stackTop];
                    result[idx] = arr[i];

                    stackTop--;
                }
                stackTop++;
                stack[stackTop] = i;
            }
            return result;
        }

        static int SolutionTask2(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                Console.WriteLine("длина: 0");
                return 0;
            }

            int n = arr.Length;
            int maxLength = 0;
            int bestStart = 0;
            int bestEnd = 0;

            int[] lastSeen = new int[1001];
            for (int i = 0; i < lastSeen.Length; i++)
            {
                lastSeen[i] = -1;
            }

            int left = 0;
            for (int right = 0; right < n; right++)
            {
                int currentNumber = arr[right];
                if (lastSeen[currentNumber] >= left)
                {
                    left = lastSeen[currentNumber] + 1;
                }
                lastSeen[currentNumber] = right;
                int currentLength = right - left + 1;
                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    bestStart = left;
                    bestEnd = right;
                }
            }
            return maxLength;
        }
    }
}
