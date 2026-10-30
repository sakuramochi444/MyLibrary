using System;
using System.Linq;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var segTree = new MaxSegTree(arr);
        Console.WriteLine(segTree.Query(0, 3));
        Console.WriteLine(segTree.Query(2, 2));
        segTree.Update(1, 8);
        Console.WriteLine(segTree.Query(0, 3));
    }
}

// Query(a, b)は[a, b]の範囲
class MaxSegTree
{
    int leaf;
    int[] segTree;
    
    
    public MaxSegTree(int[] arr)
    {
        leaf = 1;
        while(leaf < arr.Length) leaf *= 2;
        segTree = new int[leaf * 2];
        Array.Fill(segTree, int.MinValue);
        
        for(int i = 0; i < arr.Length; i++)
        {
            segTree[i + leaf] = arr[i];
        }
        
        for(int i = leaf - 1; i >= 1; i--)
        {
            segTree[i] = Math.Max(segTree[2 * i], segTree[2 * i + 1]);
        }
    }
    
    public void Update(int index, int value)
    {
        index += leaf;
        segTree[index] = value;
        while(index > 1)
        {
            index /= 2;
            segTree[index] = Math.Max(segTree[2 * index], segTree[2 * index + 1]);
        }
    }
    
    public int Query(int left, int right)
    {
        left += leaf;
        right += leaf;
        int result = int.MinValue;
        while(left <= right)
        {
            if (left % 2 == 1)
            {
                result = Math.Max(result, segTree[left]);
                left++;
            }
            if (right % 2 == 0)
            {
                result = Math.Max(result, segTree[right]);
                right--;
            }
            left /= 2;
            right /= 2;
        }
        return result;
    }
}
