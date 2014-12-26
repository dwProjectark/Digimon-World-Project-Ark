using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Node
{
    public int x            = 0;
    public int y            = 0;
    public float yCoord     = 0;
    public float xCoord     = 0;
    public float zCoord     = 0;
    public int ID           = 0;
    public bool walkable    = true;
    public Node parent      = null;

    public int F            = 0;
    public int H            = 0;
    public int G            = 0;

    //Use for faster look ups
    public int sortedIndex = -1;

    public Node(int indexX, int indexY, float height, int idValue, float xcoord, float zcoord, bool w, Node p = null)
    {
        x = indexX;
        y = indexY;
        yCoord = height;
        ID = idValue;
        xCoord = xcoord;
        zCoord = zcoord;
        walkable = w;
        parent = p;
        F = 0;
        G = 0;
        H = 0;
    }
}

