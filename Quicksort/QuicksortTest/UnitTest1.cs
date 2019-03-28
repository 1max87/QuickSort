using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quicksort;

namespace QuicksortTest
{
    [TestClass]
    public class QuickSortTest
    {
        [TestMethod]
        /*Сортировка массива из трёх элементов. После сортировки второй элемент больше первого, третий больше второго*/
        public void SortSimpleArray()
        {
            var array = QSort.GenerateArray(3);
            QSort.QuickSort(array);
            Assert.IsTrue(array[0] < array[1] && array[1] < array[2], "Simple array sorting");
        }
        /*Сортировка массива из 100 одинаковых числе работает корректно*/
        [TestMethod]
        public void SortHundredArray()
        {
            var array = new int[100];
            QSort.QuickSort(array);
            foreach (var n in array)
                Assert.IsTrue(n == array[0]);
        }

        /**
           Сортировка массива из 1000 случайных элементов.
           Проверить что 10 случайных пар элементов массива после сортировки упорядочены
           (из пары больший тот, чей индекс больше)
        **/
        [TestMethod]
        public void SortThousandArray()
        {
            var array = QSort.GenerateArray(1000);
            var indexes = QSort.GenerateArray(20, array.Length);
            QSort.QuickSort(array);
            for (var i = 0; i < indexes.Length; i += 2)
                Assert.IsTrue((array[indexes[i]] < array[indexes[1 + i]] && indexes[i] < indexes[1 + i]) ||
                            (array[indexes[i]] > array[indexes[1 + i]] && indexes[i] > indexes[1 + i]), "Normal array sorting");
        }

        // Сортировка пустого массива работает корректно
        [TestMethod]
        public void SortEmptyArray()
        {
            var array = new int[0];
            QSort.QuickSort(array);
        }

        //Сортировка массива из 1 500 000 000 элементов
        [TestMethod]
        public void SortBigArray()
        {
            var array = QSort.GenerateArray(1500000000);
            QSort.QuickSort(array);
            for (var i = 1; i < array.Length; i++)
                Assert.IsTrue(array[i - 1] < array[i]);
        }
    }
}
