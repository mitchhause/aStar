using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{

    public List<Node> frontier = new List<Node>();
    public List<Node> explored = new List<Node>();
    public GridObj[,] grid = new GridObj[10, 10];
    public Vector3 beginning = new Vector3(0, 0, 0);
    public Vector3 goal = new Vector3(0.0f, .5f, 80.0f);

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("starting");
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                GridObj g1 = new GridObj(new Vector3(i * 10f, .5f, j * 10f));
                if (i > 0)
                {
                    g1.connected.Add(grid[i - 1, j]);
                    grid[i - 1, j].connected.Add(g1);
                }

                if (j > 0)
                {
                    g1.connected.Add(grid[i, j - 1]);
                    grid[i, j - 1].connected.Add(g1);
                }
                grid[i, j] = g1;
            }
        }

        Debug.Log(aStar(grid[0, 0]));


    }
    //A* Algorithm
    public Node aStar(GridObj star)
    {

        Node begin = new Node(star);
        frontier.Add(begin);


        while (frontier.Count != 0)
        {
            Node current = frontier[0];
            frontier.RemoveAt(0);



            if (current.go.position == grid[0, 8].position)
            {
                show(current);
                return current;

            }
            else
                explored.Add(current);

            foreach (GridObj conn in current.go.connected)
            {

                Node con = new Node(conn, goal, current);

                if (inList(frontier, con) == null && inList(explored, con) == null)
                {

                    frontier.Add(con);
                    frontier.Sort();
                }

                else if (inList(frontier, con) != null)
                {
                    Node exists = inList(frontier, con);



                    if (con.cost < exists.cost)
                    {
                        frontier.Remove(exists);
                        frontier.Add(con);
                        frontier.Sort();
                    }


                }


            }


        }
        return null;
    }


    public Node inList(List<Node> lis, Node n)
    {
        foreach (Node node in lis)
        {
            if (node.go.position == n.go.position)
            {
                return node;
            }
        }
        return null;
    }


    public void show(Node s)
    {

        while (s != null)
        {


            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = s.go.position + new Vector3(0,s.go.height,0);
            s = s.prev;






        }
    }
}






    // Update is called once per frame
    
