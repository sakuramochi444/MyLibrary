using System;
using System.Linq;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.WriteLine(BinarySearch.LowerBound(a, 0));
        Console.WriteLine(BinarySearch.UpperBound(a, 0));
        Console.WriteLine(BinarySearch.Count(a, 0));
        Console.WriteLine();
        Console.WriteLine(BinarySearch.LowerBound(a, 3));
        Console.WriteLine(BinarySearch.UpperBound(a, 3));
        Console.WriteLine(BinarySearch.Count(a, 3));
        Console.WriteLine();
        Console.WriteLine(BinarySearch.LowerBound(a, 5));
        Console.WriteLine(BinarySearch.UpperBound(a, 5));
        Console.WriteLine(BinarySearch.Count(a, 5));
        Console.WriteLine();
        Console.WriteLine(BinarySearch.LowerBound(a, 9));
        Console.WriteLine(BinarySearch.UpperBound(a, 9));
        Console.WriteLine(BinarySearch.Count(a, 9));
        Console.WriteLine();
        Console.WriteLine(BinarySearch.LowerBound(a, 10));
        Console.WriteLine(BinarySearch.UpperBound(a, 10));
        Console.WriteLine(BinarySearch.Count(a, 10));
        Console.WriteLine();
        
        int[] b = new int[0];
        Console.WriteLine(BinarySearch.LowerBound(b, 2));
        Console.WriteLine(BinarySearch.UpperBound(b, 2));
        Console.WriteLine(BinarySearch.Count(b, 2));
    }
}

// 入力配列は昇順ソートが前提
class BinarySearch
{    
    public static int LowerBound(int[] a, int value)
    {
        int left = 0;
        int right = a.Length;
        
        while(left < right)
        {
            int mid = left + (right - left) / 2;
            if(a[mid] >= value) right = mid;
            else left = mid + 1;
        }
        
        return left;
    }
    
    public static int UpperBound(int[] a, int value)
    {
        int left = 0;
        int right = a.Length;
        
        while(left < right)
        {
            int mid = left + (right - left) / 2;
            if(a[mid] > value) right = mid;
            else left = mid + 1;
        }
        
        return left;
    }
    
    public static int Count(int[] a, int value)
    {
        int lower = LowerBound(a, value);
        int upper = UpperBound(a, value);
        return upper - lower;
    }
}
