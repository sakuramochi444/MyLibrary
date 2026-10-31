using System;
using System.Linq;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        int[] num = Console.ReadLine().Split().Select(int.Parse).ToArray();
        InsertionSort.Sort(num);
        Console.WriteLine(string.Join(" ", num));
        
        (int Value, string Name)[] items =
        {
            (3, "A"),
            (1, "B"),
            (3, "C"),
            (2, "D")
        };
        InsertionSort.Sort(items);
        Console.WriteLine(string.Join(" ", items));
    }
}

class InsertionSort
{
    public static void Sort(int[] a)
    {
        for(int i = 1; i < a.Length; i++)
        {
            int t = a[i];
            int j = i - 1;
            while(j >= 0 && a[j] > t)
            {
                a[j+1] = a[j];
                j--;
            }
            a[j+1] = t;
        }
    }
    
    public static void Sort((int Value, string Name)[] a)
    {
        for(int i = 1; i < a.Length; i++)
        {
            var t = a[i];
            int j = i - 1;
            while(j >= 0 && a[j].Value > t.Value)
            {
                a[j+1] = a[j];
                j--;
            }
            a[j+1] = t;
        }
    }
}