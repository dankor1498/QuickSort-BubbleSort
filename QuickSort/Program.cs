using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace QuickSortProgram
{
    class Program
    {
        private static void QuickSort(int[] array, int first, int last)
        {
            if (first < last)
            {
                int center = Partition(array, first, last);
                QuickSort(array, first, center);
                QuickSort(array, center + 1, last);
            }
        }

        static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        private static int Partition(int[] array, int first, int last)
        {
            Swap(ref array[first], ref array[last]);
            int pivot = first;
            for(int i = first; i < last; i++)
            {
                if(array[i] < array[last])
                {
                    Swap(ref array[pivot], ref array[i]);
                    pivot++; 
                }
            }
            Swap(ref array[pivot], ref array[last]);
            return pivot;
        }

        private static void BubbleSort(int[] array)
        {
            for(int i = 1; i < array.Length; ++i)
            {
                for(int j = 0; j < array.Length - i; j++)
                {
                    if (array[j] > array[j + 1])
                        Swap(ref array[j], ref array[j + 1]);
                }
            }
        }

        static void Main(string[] args)
        {
            int N = 10000;

            int[] arrayQuickSort = new int[N];
            int[] arrayBubbleSort = new int[N];

            int rand;
            Random random = new Random();
            for(int i = 0; i < N; i++)
            {
                rand = random.Next(0, 100);
                arrayQuickSort[i] = rand;
                arrayBubbleSort[i] = rand;
            }

            var watch = Stopwatch.StartNew();
            QuickSort(arrayQuickSort, 0, arrayQuickSort.Length - 1);
            watch.Stop();
            Console.WriteLine($"Runtime for quick sorting: {watch.ElapsedMilliseconds} ms.");

            watch = Stopwatch.StartNew();
            BubbleSort(arrayBubbleSort);
            watch.Stop();
            Console.WriteLine($"Runtime for bubble sorting: {watch.ElapsedMilliseconds} ms.");
        }
    }
}
