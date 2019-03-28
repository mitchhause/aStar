using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : System.IComparable
{
    public float g;
    public float h;
    public float cost;
    public GridObj go;
    public Node prev;
    
    public Node(GridObj go, Vector3 goal, Node prev)
    {
        this.go = go;
        g = (go.position - prev.go.position).magnitude + prev.g + go.height;
        h = (go.position - goal).magnitude;
        cost = h + g;
        this.prev = prev;
    }

    public Node(GridObj go)
    {
        this.go = go;
        g = 0;
        h = 0;
        cost = 0;
        prev = null;
    }

    // Update is called once per frame
    public int CompareTo(object obj)
    {
        Node n = (Node) obj;

        if (cost > n.cost)
            return 1;
        else if (cost == n.cost)
            return 0;
        else
            return -1;
    }
}
