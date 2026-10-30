using System;
using System.Linq;
using System.Collections.Generic;
class PartialSum
{
    public static int n = int.Parse(Console.ReadLine());
    public static int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
    public static int k = int.Parse(Console.ReadLine());

    static void Main(string[] args)
    {
        Console.WriteLine(Check(0, 0) ? "Yes" : "No");
    }

    static bool Check(int i, int sum)
    {
        if (i == n) return sum == k;

        return Check(i + 1, sum) || Check(i + 1, sum + a[i]);

        return false;a
    }
}