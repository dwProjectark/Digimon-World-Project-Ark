using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class NodeSearch : IComparable<NodeSearch>
{
    private int id = 0;
    public int F = 0;
    public float Fv = 0F;

    public int ID
    {
        get
        {
            return id;
        }
        private set
        {
            this.id = value;
        }
    }
    
    public NodeSearch(int i, int f)
    {
        id = i;
        F = f;
    }

    public NodeSearch(int i, float f)
    {
        id = i;
        Fv = f;
    }


    public int CompareTo(NodeSearch b)
    {
        return this.F.CompareTo(b.F);
    }
}

public class SortOnFvalue : IComparer<NodeSearch>
{
    public int Compare(NodeSearch a, NodeSearch b)
    {
        if (a.F > b.F) return 1;
        else if (a.F < b.F) return -1;
        else return 0;
    }
}
