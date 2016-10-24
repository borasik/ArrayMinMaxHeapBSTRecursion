using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayMinMaxHeapBSTRecursion
{
    class Program
    {
        public static List<int> array = new List<int> { 2, 5, -4, 0, 300, 208, 500, -1000 };
        static void Main(string[] args)
        {
            Heap heap = new Heap();
            heap.BuildMinHeap(array);

            Recursion recursion = new Recursion();
            var min = recursion.FindMinMax(array, 0, array.Count - 1).min;
            var max = recursion.FindMinMax(array, 0, array.Count - 1).max;
            Console.Write("Max: " + max + " Min: " + min);
        }
    }

    public class Heap
    {
        public void BuildMinHeap(List<int> array)
        {
            for (int i = (array.Count() - 1) / 2; i >= 0; i--)
            {
                Heapify(array, i, array.Count() - 1);
            }
        }
        public void Heapify(List<int> array, int index, int arraySize)
        {
            var left = index * 2 + 1;
            var right = index * 2 + 2;
            var lagest = index;

            if(left <= arraySize && array[left] < array[index])
            {
                lagest = left;
            }            

            if(right <= arraySize && array[right] < array[lagest])
            {
                lagest = right;
            }

            if (lagest != index)
            {
                var temp = array[index];
                array[index] = array[lagest];
                array[lagest] = temp;

                Heapify(array, lagest, arraySize);
            }           
        }
    }

    public class Recursion
    {
        public Pair FindMinMax(List<int> array, int high, int low)
        {
            Pair result = new Pair();
            Pair left = new Pair();
            Pair right = new Pair();

            if (low == high)
            {
                result.max = array[low];
                result.max = array[high];
                return result;
            }

            if(high == low + 1)
            {
                if(array[low] > array[high])
                {
                    result.max = array[low];
                    result.min = array[high];
                }
                else
                {
                    result.max = array[high];
                    result.min = array[low];
                }

                return result;
            }

            int mid = (low + high) / 2;
            left = FindMinMax(array, low, mid);
            right = FindMinMax(array, mid + 1, high);

            if (left.min < right.min)
                result.min = left.min;
            else
                result.min = right.min;

            if (left.max > right.max)
                result.max = left.max;
            else
                result.max = right.max;

            return result;
        }
    }
    public class Pair
    {
        public int min { get; set; }
        public int max { get; set; }
    }
}
