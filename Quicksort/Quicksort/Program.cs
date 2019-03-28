using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quicksort
{
    public class QSort
    {
        /// <summary>
        /// Реализация алгоритма быстрой сортировки
        /// </summary>
        /// <param name="array"></param>
        public static void QuickSort(int[] array)
        {
            quickSort(array, 0, array.Length - 1);
        }

        // Функция быстрой сортировки
       static void quickSort(int[] numbers, int left, int right)
        {
            int pivot; // разрешающий элемент
            int l_hold = left; //левая граница
            int r_hold = right; // правая граница
            pivot = numbers[left];
            while (left < right) // пока границы не сомкнутся
            {
                while ((numbers[right] >= pivot) && (left < right))
                    right--; // сдвигаем правую границу пока элемент [right] больше [pivot]
                if (left != right) // если границы не сомкнулись
                {
                    numbers[left] = numbers[right]; // перемещаем элемент [right] на место разрешающего
                    left++; // сдвигаем левую границу вправо 
                }
                while ((numbers[left] <= pivot) && (left < right))
                    left++; // сдвигаем левую границу пока элемент [left] меньше [pivot]
                if (left != right) // если границы не сомкнулись
                {
                    numbers[right] = numbers[left]; // перемещаем элемент [left] на место [right]
                    right--; // сдвигаем правую границу вправо 
                }
            }
            numbers[left] = pivot; // ставим разрешающий элемент на место
            pivot = left;
            left = l_hold;
            right = r_hold;
            if (left < pivot) // Рекурсивно вызываем сортировку для левой и правой части массива
                quickSort(numbers, left, pivot - 1);
            if (right > pivot)
                quickSort(numbers, pivot + 1, right);
        }

        // генерирование массива
      public static int[] GenerateArray(int length, int maxValue = int.MaxValue)
       {
           var random = new Random(50);
           var array = new int[length];
           for (var i = 0; i < length; ++i)
               array[i] = random.Next(maxValue);
           return array;
       }

      static void Main(string[] args)
      {
      }
    }
}

