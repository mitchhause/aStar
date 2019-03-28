using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObj 

   

{
  
    public float height;
    public Vector3 position;
    public HashSet<GridObj> connected = new HashSet<GridObj>();

    
   public GridObj(Vector3 position)
    {
        height = Terrain.activeTerrain.SampleHeight(position);
        this.position = position;
      

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
