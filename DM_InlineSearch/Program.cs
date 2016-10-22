using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_InlineSearch
{
    class Program
    {

        static void Main(string[] args)
        {
            Random rand = new Random();
            #region Генерация массива
            Console.WriteLine("//////////////////////////////////////////////////////////////////");
            Console.WriteLine("/////////////////////////// Inline Search ////////////////////////");
            Console.WriteLine("//////////////////////////////////////////////////////////////////");
            Console.Write("Enter length of massive ->");
            bool tmp = false;
            int n = 0;

            do
            {
                try
                {
                    n = Convert.ToInt32(Console.ReadLine());
                    tmp = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Incorrect length");
                    Console.Write("Enter length of massive ->");
                    tmp = true;
                }
            } while (tmp);

            int[] arr = new int[n];
            Console.WriteLine("Massive generating..");
            RandomGenerate(arr);
            Console.WriteLine("Done.");
            #endregion
            #region Инициализация количества повторений
            Console.Write("Enter number of repetitions ->");
            tmp = false;
            int repetitions = 0;
            do
            {
                try
                {
                    repetitions = Convert.ToInt32(Console.ReadLine());
                    tmp = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Incorrect number");
                    Console.Write("Enter number of repetitions ->");
                    tmp = true;
                }
            } while (tmp);
            Console.WriteLine("Correct.");
            #endregion
            #region Эксперимент
            Console.WriteLine("Experiment in process");
            int inlineSum = 0;
            int minInline = n + 1;
            int maxInline = 0;

            int binarySum = 0;
            int minBinary = n + 1;
            int maxBinary = 0;

            for (int i = 0; i < repetitions; i++)
            {
                int keyN = rand.Next(n);
                int countI = InlineSearchCount(arr, keyN);
                int countB = BinarySearchCount(arr, keyN);

                inlineSum += countI;
                binarySum += countB;

                if (countI < minInline)
                    minInline = countI;
                if (countI > maxInline)
                    maxInline = countI;

                if (countB < minBinary)
                    minBinary = countB;
                if (countB > maxBinary)
                    maxBinary = countB;

                RandomGenerate(arr);
            }
            #endregion
            #region Вывод результата
            Console.WriteLine();
            Console.WriteLine("============================  Resaults  ==========================");
            Console.WriteLine();
            Console.WriteLine("Number of actions in INLINE SEARCH {0}", inlineSum / repetitions);
            Console.WriteLine("Number of actions in BINARY SEARCH {0}", binarySum / repetitions);
            Console.WriteLine();
            Console.WriteLine("Min of actions in INLINE SEARCH {0}", minInline);
            Console.WriteLine("Min of actions in BINARY SEARCH {0}", minBinary);
            Console.WriteLine();
            Console.WriteLine("Max of actions in INLINE SEARCH {0}", maxInline);
            Console.WriteLine("Max of actions in BINARY SEARCH {0}", maxBinary);
            Console.ReadKey();
            #endregion
        }

        static private void RandomGenerate(int[] arr)
        {
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(200) - 100;
            }
        }

        static private int InlineSearchCount(int[] arr, int key)
        {
            int count = 0;

            while (arr[count] != arr[key])
            {
                count++;
            }


            return count++;
        }

        static private int BinarySearchCount(int[] arr, int key)
        {
            int count = 0;
            Sort(arr);
            int i = -1;
            if (arr != null)
            {
                int low = 0, high = arr.Length, mid;
                while (low < high)
                {
                    count++;
                    mid = (low + high) / 2; // Можно заменить на расчёт в беззнаковом типе: (low + high) >>> 1 
                    if (arr[key] == arr[mid])
                    {

                        i = mid;
                        break;
                    }
                    else
                    {
                        if (arr[key] < arr[mid])
                        {

                            high = mid;
                        }
                        else
                        {
                            low = mid + 1;
                        }
                    }
                }

            }
            return count;
        }

        static private void Sort(int[] arr)
        {
            int n = arr.Length;
            int Count = 0;
            int d = arr.Length / 2; // начальное значение интервала
            while (d > 0)  // цикл с уменьшением интервала до 1
            {
                bool Ok = true; // пузырьковая с интервалом d
                while (Ok)      // цикл, пока есть перестановки
                {
                    Ok = false;
                    for (int i = 0; i < n - d; i++)
                        // сравнение эл-тов на интервале d
                        if (arr[i] > arr[i + d])
                        {
                            int t = arr[i]; arr[i] = arr[i + d];
                            arr[i + d] = t; // перестановка
                            Ok = true; // признак перестановки
                            Count++;
                        }
                }
                d = d / 2;    // уменьшение интервала
            }


        }
    }
}
