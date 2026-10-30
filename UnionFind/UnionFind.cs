using System;
using System.Linq;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        var dsu = new UnionFind(5);
        Console.WriteLine(dsu.Size(0));
        Console.WriteLine(dsu.Same(0, 1) ? "true" : "false");
        dsu.Unite(0, 1);
        dsu.Unite(2, 3);
        dsu.Unite(1, 3);
        Console.WriteLine(dsu.Same(0, 2) ? "true" : "false");
        Console.WriteLine(dsu.Size(3));
        dsu.Unite(0, 3);
        Console.WriteLine(dsu.Size(0));
        Console.WriteLine(dsu.Same(0, 4) ? "true" : "false");
    }
}

class UnionFind
{
    int[] parent;
    int[] size;
    
    public UnionFind(int n)
    {
        parent = new int[n];
        size = new int[n];
        for(int i = 0; i < n; i++) 
        {
            parent[i] = i;
            size[i] = 1;
        }
    }
    
    public int Find(int x)
    {
        while(parent[x] != x)
        {
            parent[x] = parent[parent[x]];
            x = parent[x];
        }
        return x;
    }
    
    public void Unite(int a, int b)
    {
        int aRoot = Find(a);
        int bRoot = Find(b);
        if(aRoot != bRoot)
        {
            if(size[aRoot] > size[bRoot])
            {
                parent[bRoot] = aRoot;
                size[aRoot] += size[bRoot];
            }
            else
            {
                parent[aRoot] = bRoot;
                size[bRoot] += size[aRoot];
            }
        }
    }
    
    public bool Same(int a, int b)
    {
        int aRoot = Find(a);
        int bRoot = Find(b);
        return aRoot == bRoot;
    }
    
    public int Size(int x)
    {
        return size[Find(x)];
    }
}
