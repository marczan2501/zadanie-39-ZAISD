using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FindSum
{
    class FindSums
    {
        int t;
        int[] table;

        public FindSums(int tabSize, int t)
        {
            table = createTab(tabSize);
            this.t = t;
        }

        public void find_sum()
        {
            int n = table.Length;
            int found = 0;

            Stopwatch timer = Stopwatch.StartNew();

            table = quick_sort(table, 0, n - 1);
            for (int i = 0; i < n - 1; i++)
            {
                int j = i + 1;
                int k = n - 1;
                while (k > j)
                {
                    int sum = table[i] + table[j] + table[k];
                    if (sum == t)
                    {
                        Console.WriteLine(table[i] + " + " + table[j] + " + " + table[k] + " = " + sum);
                        found += 1;
                        k -= 1;
                        j += 1;
                    }
                    else if (sum > t) k -= 1; 
                    else  j += 1;  
                }
            }
            timer.Stop();
            Console.WriteLine("Znaleziono " + found + " rozwiązań w czasie " + timer.ElapsedMilliseconds + "ms");
        }  
        // Tworzenie tablicy wypełnionej losowymi elementami

        private int[] createTab(int size)
        {  
            List<int> tab = new List<int>();
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                int number = -size + random.Next(size * 3);
                if (!tab.Contains(number)) tab.Add(number);
            }

            return tab.ToArray();
        }

        // Quick Sort stworzonej tablicy

        private int[] quick_sort(int[] keys, int left, int right)
        {
            if (left < right)
            {
                int pivot = partition(ref keys, left, right);
                quick_sort(keys, left, pivot - 1);
                quick_sort(keys, pivot + 1, right);
            }
            return keys;
        }

        private int partition(ref int[] keys, int left, int right)
        {
            int x = keys[right];
            int i = left - 1;
            int temp;
            for (int j = left; j < right; j++)
            {
                if (keys[j] <= x)
                {
                    i += 1;
                    temp = keys[i];
                    keys[i] = keys[j];
                    keys[j] = temp;
                }
            }
            temp = keys[i + 1];
            keys[i + 1] = keys[right];
            keys[right] = temp;
            return i + 1;
        }
    }
}
