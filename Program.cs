using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_AISD_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] arrays = new int[][]
            {
                new int[] { 1, 2, 6, 13, 23 },
                new int[] { 1, 6, 6, 7, 9, 10 },
                new int[] { 8, 12, 13 },
                new int[] { 9, 10 }
            };

            int[] result = SortedArrays_1(arrays);
            Console.WriteLine(string.Join(" ", result));

            int[] numbers = { 3, 30, 34, 5, 9 };

            string resultat = LargestNumber(numbers);
            Console.WriteLine($"Наибольшее число: {resultat}");
        }
        static int[] SortedArrays_1(int[][] arrays)
        {
            int k = arrays.Length;
            int totalLength = 0;
            for (int i = 0; i < k; i++)
            {
                totalLength += arrays[i].Length;
            }

            int[] result = new int[totalLength];

            int[] currentPositions = new int[k];

            for (int i = 0; i < k; i++)
            {
                currentPositions[i] = 0;
            }

            for (int resultIndex = 0; resultIndex < totalLength; resultIndex++)
            {
                int minValue = int.MaxValue;
                int minArrayIndex = -1;

                for (int i = 0; i < k; i++)
                {
                    if (currentPositions[i] < arrays[i].Length)
                    {
                        int currentValue = arrays[i][currentPositions[i]];
                        if (currentValue < minValue)
                        {
                            minValue = currentValue;
                            minArrayIndex = i;
                        }
                    }
                }
                result[resultIndex] = minValue;

                currentPositions[minArrayIndex]++;
            }

            return result;
        }
        static string LargestNumber(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return "";

            string[] strNums = new string[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                strNums[i] = nums[i].ToString();
            }
            for (int i = 0; i < strNums.Length - 1; i++)
            {
                for (int j = i + 1; j < strNums.Length; j++)
                {
                    string order1 = strNums[i] + strNums[j];
                    string order2 = strNums[j] + strNums[i];

                    if (string.Compare(order2, order1) > 0)
                    {
                        string temp = strNums[i];
                        strNums[i] = strNums[j];
                        strNums[j] = temp;
                    }
                }
            }
            string result = "";
            for (int i = 0; i < strNums.Length; i++)
            {
                result = result + strNums[i];
            }
            if (result[0] == '0')
                return "0";

            return result;
        }
    }
}
