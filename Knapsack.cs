using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] num = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = num[0];
        int W = num[1];
        
        int[] w = new int[n];
        int[] v = new int[n];

        for (int i = 0; i < n; i++)
        {
            int[] t = Console.ReadLine().Split().Select(int.Parse).ToArray();
            w[i] = t[0];
            v[i] = t[1];
        }
        
        int maxV = v.Sum();
        long[,] dp = new long[n + 1, maxV + 1];
        
        for(int i = 0; i <= n; i++) for(int j = 0; j <= maxV; j++) dp[i, j] = (long)W + 1;
        dp[0, 0] = 0;
        
        for(int i = 0; i < n; i++)
        {
            for(int sumV = 0; sumV <= maxV; sumV++)
            {
                if(sumV - v[i] >= 0)
                {
                    dp[i+1, sumV] = Math.Min(dp[i+1, sumV], dp[i, sumV - v[i]] + w[i]);
                }
                dp[i+1, sumV] = Math.Min(dp[i+1, sumV], dp[i, sumV]);
            }
        }
        
        long ans = 0;
        for(int i = 0; i <= maxV; i++)
        {
            if(dp[n, i] <= W) ans = i;
        }
        Console.WriteLine(ans);
    }
}


